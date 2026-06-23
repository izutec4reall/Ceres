using Ceres.Annotations;
using Ceres.Graph.Flow.Annotations;
using UnityEngine;

namespace Ceres.Graph.Flow.Utilities
{
    [CeresGroup("Physics")]
    public partial class PhysicsExecutableLibrary : ExecutableFunctionLibrary
    {
        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Add Force")]
        public static void Flow_AddForce(Rigidbody rigidbody, Vector3 force, ForceMode mode)
        {
            rigidbody.AddForce(force, mode);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Add Torque")]
        public static void Flow_AddTorque(Rigidbody rigidbody, Vector3 torque, ForceMode mode)
        {
            rigidbody.AddTorque(torque, mode);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Velocity")]
        public static Vector3 Flow_GetVelocity(Rigidbody rigidbody)
        {
            return rigidbody.velocity;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Velocity")]
        public static void Flow_SetVelocity(Rigidbody rigidbody, Vector3 velocity)
        {
            rigidbody.velocity = velocity;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Is Kinematic")]
        public static bool Flow_IsKinematic(Rigidbody rigidbody)
        {
            return rigidbody.isKinematic;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Kinematic")]
        public static void Flow_SetKinematic(Rigidbody rigidbody, bool value)
        {
            rigidbody.isKinematic = value;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Add Explosion Force")]
        public static void Flow_AddExplosionForce(Rigidbody rigidbody, float force, Vector3 position, float radius, float upwardsModifier)
        {
            rigidbody.AddExplosionForce(force, position, radius, upwardsModifier);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Move Position")]
        public static void Flow_MovePosition(Rigidbody rigidbody, Vector3 position)
        {
            rigidbody.MovePosition(position);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Move Rotation")]
        public static void Flow_MoveRotation(Rigidbody rigidbody, Quaternion rotation)
        {
            rigidbody.MoveRotation(rotation);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Mass")]
        public static float Flow_GetMass(Rigidbody rigidbody)
        {
            return rigidbody.mass;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Mass")]
        public static void Flow_SetMass(Rigidbody rigidbody, float mass)
        {
            rigidbody.mass = mass;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Drag")]
        public static float Flow_GetDrag(Rigidbody rigidbody)
        {
            return rigidbody.drag;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Drag")]
        public static void Flow_SetDrag(Rigidbody rigidbody, float drag)
        {
            rigidbody.drag = drag;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Angular Drag")]
        public static float Flow_GetAngularDrag(Rigidbody rigidbody)
        {
            return rigidbody.angularDrag;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Angular Drag")]
        public static void Flow_SetAngularDrag(Rigidbody rigidbody, float angularDrag)
        {
            rigidbody.angularDrag = angularDrag;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Use Gravity")]
        public static bool Flow_GetUseGravity(Rigidbody rigidbody)
        {
            return rigidbody.useGravity;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Use Gravity")]
        public static void Flow_SetUseGravity(Rigidbody rigidbody, bool useGravity)
        {
            rigidbody.useGravity = useGravity;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Sleep")]
        public static void Flow_Sleep(Rigidbody rigidbody)
        {
            rigidbody.Sleep();
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Wake Up")]
        public static void Flow_WakeUp(Rigidbody rigidbody)
        {
            rigidbody.WakeUp();
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Is Sleeping")]
        public static bool Flow_IsSleeping(Rigidbody rigidbody)
        {
            return rigidbody.IsSleeping();
        }

        #region Character Controller

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Simple Move")]
        public static void Flow_SimpleMove(CharacterController controller, Vector3 speed)
        {
            controller.SimpleMove(speed);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Move")]
        public static void Flow_Move(CharacterController controller, Vector3 motion)
        {
            controller.Move(motion);
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Is Grounded")]
        public static bool Flow_IsGrounded(CharacterController controller)
        {
            return controller.isGrounded;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Height")]
        public static float Flow_GetHeight(CharacterController controller)
        {
            return controller.height;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Height")]
        public static void Flow_SetHeight(CharacterController controller, float height)
        {
            controller.height = height;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Radius")]
        public static float Flow_GetRadius(CharacterController controller)
        {
            return controller.radius;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Radius")]
        public static void Flow_SetRadius(CharacterController controller, float radius)
        {
            controller.radius = radius;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Center")]
        public static Vector3 Flow_GetCenter(CharacterController controller)
        {
            return controller.center;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Center")]
        public static void Flow_SetCenter(CharacterController controller, Vector3 center)
        {
            controller.center = center;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Slope Limit")]
        public static float Flow_GetSlopeLimit(CharacterController controller)
        {
            return controller.slopeLimit;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Slope Limit")]
        public static void Flow_SetSlopeLimit(CharacterController controller, float slopeLimit)
        {
            controller.slopeLimit = slopeLimit;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true, ExecuteInDependency = true), CeresLabel("Get Step Offset")]
        public static float Flow_GetStepOffset(CharacterController controller)
        {
            return controller.stepOffset;
        }

        [ExecutableFunction(IsScriptMethod = true, IsSelfTarget = true), CeresLabel("Set Step Offset")]
        public static void Flow_SetStepOffset(CharacterController controller, float stepOffset)
        {
            controller.stepOffset = stepOffset;
        }

        #endregion
    }
}
