using System;
using System.Collections.Generic;
using System.Linq;
using Ceres.Graph;
using Ceres.Graph.Flow;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ceres.Editor.Graph.Flow
{
    [CustomEditor(typeof(FlowGraphObjectBase), true)]
    [CanEditMultipleObjects]
    public class FlowGraphObjectEditor : UnityEditor.Editor
    {
        private class OpenFlowGraphButton : Button
        {
            private const string ButtonText = "Open Flow Graph";

            public OpenFlowGraphButton(IFlowGraphContainer container) : base(() => FlowGraphEditorWindow.Show(container))
            {
                style.fontSize = 15;
                style.unityFontStyleAndWeight = FontStyle.Bold;
                style.color = Color.white;
                style.backgroundColor = new StyleColor(new Color(89 / 255f, 133 / 255f, 141 / 255f));
                text = ButtonText;
                Add(new Image
                {
                    style =
                    {
                        backgroundImage = Resources.Load<Texture2D>("Ceres/editor_icon"),
                        height = 20,
                        width = 20
                    }
                });
                style.height = 25;
            }
        }

        private FlowGraphObjectBase Target => (FlowGraphObjectBase)target;

        private IFlowGraphContainer _container;

        private FlowGraph _graphInstance;

        private SerializedProperty _localOverridesProp;

        private VisualElement _blackboardPanel;

        private bool _hasContainer;

        public void OnEnable()
        {
            _localOverridesProp = serializedObject.FindProperty("localOverrides");
            _container = GetContainer(Target);
            _hasContainer = _container != null;
        }

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            // Default properties (skip m_Script, localOverrides)
            var property = serializedObject.GetIterator();
            property.NextVisible(true);
            var visitedOverrides = false;
            while (property.NextVisible(false))
            {
                if (property.name == "localOverrides") continue;
                if (property.propertyPath == "m_Script") continue;
                var propField = new PropertyField(property.Copy());
                propField.Bind(serializedObject);
                root.Add(propField);
            }

            // Blackboard overrides panel
            _blackboardPanel = new VisualElement();
            root.Add(_blackboardPanel);

            if (_hasContainer)
            {
                BuildBlackboardPanel();
            }
            else
            {
                _blackboardPanel.Add(new Label("No Flow Graph Asset assigned")
                {
                    style = { color = Color.gray, marginTop = 8 }
                });
            }

            // Open Flow Graph button
            if (_hasContainer)
            {
                root.Add(new OpenFlowGraphButton(_container));
            }

            return root;
        }

        private void BuildBlackboardPanel()
        {
            _blackboardPanel.Clear();

            if (_container == null) return;

            GraphInstanceCleanup();
            _graphInstance = _container.GetFlowGraph();
            _graphInstance.AOT();

            var exposedVars = _graphInstance.Blackboard.GetExposedVariables();
            if (exposedVars.Length == 0)
            {
                _blackboardPanel.Add(new Label("Exposed Variables: None")
                {
                    style = { color = Color.gray, unityFontStyleAndWeight = FontStyle.Bold, marginTop = 6, marginBottom = 4 }
                });
                return;
            }

            var title = new Label("Exposed Variables")
            {
                style = { unityFontStyleAndWeight = FontStyle.Bold, marginTop = 8, marginBottom = 4 }
            };
            _blackboardPanel.Add(title);

            var factory = FieldResolverFactory.Get();
            var overridesList = GetOverrideList();

            foreach (var variable in exposedVars)
            {
                var row = new VisualElement();
                row.style.flexDirection = FlexDirection.Row;
                row.style.marginBottom = 2;
                row.style.alignItems = Align.Center;

                var label = new Label($"{variable.Name}")
                {
                    style = { width = 80, minWidth = 80, fontSize = 11 }
                };
                row.Add(label);

                var existingOverride = overridesList?.FirstOrDefault(v => v.Name == variable.Name);

                if (existingOverride != null)
                {
                    // Has override - find the SerializedProperty for this override
                    bool foundProp = false;
                    if (_localOverridesProp != null && _localOverridesProp.isArray)
                    {
                        for (int i = 0; i < _localOverridesProp.arraySize; i++)
                        {
                            var elem = _localOverridesProp.GetArrayElementAtIndex(i);
                            var nameProp = elem.FindPropertyRelative("mName");
                            if (nameProp?.stringValue == variable.Name)
                            {
                                var valueField = new PropertyField(elem, "");
                                valueField.Bind(serializedObject);
                                valueField.style.flexGrow = 1;
                                row.Add(valueField);
                                foundProp = true;
                                break;
                            }
                        }
                    }

                    if (!foundProp)
                    {
                        AddInlineField(row, variable, true);
                    }

                    // Revert button
                    var revertBtn = new Button(() =>
                    {
                        RemoveOverride(variable.Name);
                        BuildBlackboardPanel();
                    })
                    {
                        text = "\u21BA",
                        tooltip = "Revert to asset default",
                        style = { width = 22, height = 18, fontSize = 14, marginLeft = 4 }
                    };
                    row.Add(revertBtn);
                }
                else
                {
                    // No override - show inline field that creates override on change
                    AddInlineField(row, variable, false);

                    Label overrideLabel = null;
                    var field = row.Children().Last();
                    var fieldElement = field;

                    // Register change to create override
                    if (field is TextField tf)
                    {
                        tf.RegisterValueChangedCallback(evt =>
                        {
                            if (evt.newValue != variable.GetValue()?.ToString())
                            {
                                AddOverride(variable, evt.newValue);
                                BuildBlackboardPanel();
                            }
                        });
                    }
                }

                _blackboardPanel.Add(row);
            }
        }

        private void AddInlineField(VisualElement row, SharedVariable variable, bool isOverride)
        {
            var factory = FieldResolverFactory.Get();
            var fieldInfo = variable.GetType().GetField("value",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (fieldInfo != null)
            {
                var fieldResolver = factory.Create(fieldInfo);
                var valueField = fieldResolver.EditorField;
                fieldResolver.Restore(variable);
                valueField.style.flexGrow = 1;

                if (!isOverride)
                {
                    fieldResolver.RegisterValueChangeCallback(obj =>
                    {
                        AddOverride(variable, obj);
                        BuildBlackboardPanel();
                    });
                }

                row.Add(valueField);
            }
        }

        private void AddOverride(SharedVariable variable, object newValue)
        {
            if (_localOverridesProp == null) return;
            var clone = variable.Clone();
            clone.SetValue(newValue);
            serializedObject.Update();
            var index = _localOverridesProp.arraySize;
            _localOverridesProp.InsertArrayElementAtIndex(index);
            var elem = _localOverridesProp.GetArrayElementAtIndex(index);
            var nameProp = elem.FindPropertyRelative("mName");
            if (nameProp != null) nameProp.stringValue = variable.Name;
            serializedObject.ApplyModifiedProperties();
        }

        private void RemoveOverride(string variableName)
        {
            if (_localOverridesProp == null) return;
            serializedObject.Update();
            for (int i = 0; i < _localOverridesProp.arraySize; i++)
            {
                var elem = _localOverridesProp.GetArrayElementAtIndex(i);
                var nameProp = elem.FindPropertyRelative("mName");
                if (nameProp?.stringValue == variableName)
                {
                    _localOverridesProp.DeleteArrayElementAtIndex(i);
                    break;
                }
            }
            serializedObject.ApplyModifiedProperties();
        }

        private List<SharedVariable> GetOverrideList()
        {
            return Target?.GetLocalOverrides();
        }

        private static IFlowGraphContainer GetContainer(FlowGraphObjectBase objBase)
        {
            if (objBase is IFlowGraphContainer c) return c;
            if (objBase is FlowGraphInstanceObject instance)
            {
                var asset = instance.graphAsset;
                if (asset != null) return asset;
            }
            return null;
        }

        private void GraphInstanceCleanup()
        {
            if (_graphInstance != null)
            {
                try { _graphInstance.Dispose(); } catch { }
                _graphInstance = null;
            }
        }

        private void OnDisable()
        {
            GraphInstanceCleanup();
        }
    }
}
