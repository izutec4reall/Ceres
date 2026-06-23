# Ceres Fork — سجل التعديلات

**النسخة:** v0.8.0-beta  
**الفورك:** [izutec4reall/Ceres](https://github.com/izutec4reall/Ceres)  
**التاريخ:** 2026-06-23

---

## التعديلات

### 1. مكتبة Input جاهزة — `InputExecutableLibrary.cs`
**المسار:** `Runtime/Flow/Models/Libraries/InputExecutableLibrary.cs`

دوال Input كعُقد Node في Flow Graph:
- `Get Axis` — `Input.GetAxis(axisName)`
- `Get Axis Raw` — `Input.GetAxisRaw(axisName)`
- `Get Button` / `Get Button Down` / `Get Button Up`
- `Get Key` / `Get Key Down` / `Get Key Up` — تستقبل `KeyCode`
- `Get Mouse Button` / Down / Up
- `Get Mouse Position`
- `Any Key` / `Any Key Down`
- `Get Mouse Scroll Delta`

كل الدوال `ExecuteInDependency = true` (تشتغل بدون exec connection).

---

### 2. مكتبة Physics جاهزة — `PhysicsExecutableLibrary.cs`
**المسار:** `Runtime/Flow/Models/Libraries/PhysicsExecutableLibrary.cs`

**Rigidbody:**
- `Add Force` / `Add Torque` / `Add Explosion Force`
- `Get/Set Velocity`
- `Move Position` / `Move Rotation`
- `Get/Set Mass`, `Get/Set Drag`, `Get/Set Angular Drag`
- `Get/Set Use Gravity`
- `Sleep` / `Wake Up` / `Is Sleeping`

**CharacterController:**
- `Simple Move` / `Move`
- `Is Grounded`
- `Get/Set Height`, `Get/Set Radius`
- `Get/Set Center`, `Get/Set Slope Limit`, `Get/Set Step Offset`

---

### 3. Component جاهز بكل الأحداث — `FlowGameBehaviour.cs`
**المسار:** `Runtime/Flow/FlowGameBehaviour.cs`

Component واحد يركب على أي GameObject ويحتوي كل أحداث Unity:
- `Awake`, `Start`, `Update`, `FixedUpdate`, `LateUpdate`
- `OnEnable`, `OnDisable`, `OnDestroy`
- `OnCollisionEnter/Stay/Exit` (2D و 3D)
- `OnTriggerEnter/Stay/Exit` (2D و 3D)
- `OnMouseDown/Up/Drag`
- `OnAnimatorMove`, `OnAnimatorIK`
- `OnBecameVisible`, `OnBecameInvisible`

يظهر في قائمة **Add Component → Ceres → Flow Game Behaviour**.

---

### 4. نظام Override المتغيرات لكل Instance — `FlowGraphObjectBase.cs`
**المسار:** `Runtime/Flow/FlowGraphObject.cs`

- أضفنا `localOverrides` (حقل `List<SharedVariable>`) لكل MonoBehaviour
- بعد Compile الـ Graph، يدمج (merge) الـ overrides في الـ Blackboard تلقائياً
- `GetLocalOverrides()` / `SetLocalOverride()` / `RemoveLocalOverride()`
- يسمح بتعديل قيم المتغيرات لكل GameObject على حدة (مثلاً Speed مختلف لكل لاعب)

---

### 5. Inspector مخصص — `FlowGraphObjectEditor.cs`
**المسار:** `Editor/Flow/FlowGraphObjectEditor.cs`

- `[CustomEditor(typeof(FlowGraphObjectBase), true)]` — يشتغل لكل الـ Flow components
- `[CanEditMultipleObjects]` — يدعم التحديد المتعدد
- **UIElements (`CreateInspectorGUI`)** — واجهة حديثة
- **لوحة Exposed Variables** — تعرض كل متغيرات الـ Blackboard داخل Inspector
- **Override تلقائي** — إذا غيرت قيمة variable، ينشئ override تلقائياً
- **Revert Button (↺)** — يرجع القيمة إلى default الـ asset
- **Open Flow Graph** — زر يفتح Graph Editor

---

### 6. تعديلات الـ .gitignore
- أضفنا `/Ceres/` (يمنع مشكلة الـ submodule)
- أضفنا `/com.unity.visualscripting` (يمنع رفع Unity VS package)
- أضفنا `/_DevNotes` (يمنع رفع مجلد التجارب)

---

### 7. إصدار Beta
```
git tag v0.8.0-beta
git push origin v0.8.0-beta
```

---

## خطط قادمة

- [ ] إضافة مكتبة Audio (PlaySound, SetVolume...)
- [ ] إضافة مكتبة Animation (Play, SetTrigger, SetFloat...)
- [ ] إضافة مكتبة UI (SetText, SetActive, SetColor...)
- [ ] إضافة Spawn/Instantiate معلمات
- [ ] تحسين الـ Inspector (تصنيف المتغيرات)
