using Ceres.Annotations;
using Ceres.Graph.Flow.Annotations;
using UnityEngine;

namespace Ceres.Graph.Flow.Utilities
{
    [CeresGroup("Input")]
    public partial class InputExecutableLibrary : ExecutableFunctionLibrary
    {
        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Axis")]
        public static float Flow_GetAxis(string axisName)
        {
            return Input.GetAxis(axisName);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Axis Raw")]
        public static float Flow_GetAxisRaw(string axisName)
        {
            return Input.GetAxisRaw(axisName);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Button")]
        public static bool Flow_GetButton(string buttonName)
        {
            return Input.GetButton(buttonName);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Button Down")]
        public static bool Flow_GetButtonDown(string buttonName)
        {
            return Input.GetButtonDown(buttonName);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Button Up")]
        public static bool Flow_GetButtonUp(string buttonName)
        {
            return Input.GetButtonUp(buttonName);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Key")]
        public static bool Flow_GetKey(KeyCode key)
        {
            return Input.GetKey(key);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Key Down")]
        public static bool Flow_GetKeyDown(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Key Up")]
        public static bool Flow_GetKeyUp(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Mouse Button")]
        public static bool Flow_GetMouseButton(int button)
        {
            return Input.GetMouseButton(button);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Mouse Button Down")]
        public static bool Flow_GetMouseButtonDown(int button)
        {
            return Input.GetMouseButtonDown(button);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Mouse Button Up")]
        public static bool Flow_GetMouseButtonUp(int button)
        {
            return Input.GetMouseButtonUp(button);
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Mouse Position")]
        public static Vector3 Flow_GetMousePosition()
        {
            return Input.mousePosition;
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Any Key")]
        public static bool Flow_AnyKey()
        {
            return Input.anyKey;
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Any Key Down")]
        public static bool Flow_AnyKeyDown()
        {
            return Input.anyKeyDown;
        }

        [ExecutableFunction(ExecuteInDependency = true), CeresLabel("Get Mouse Scroll Delta")]
        public static Vector2 Flow_GetMouseScrollDelta()
        {
            return Input.mouseScrollDelta;
        }
    }
}
