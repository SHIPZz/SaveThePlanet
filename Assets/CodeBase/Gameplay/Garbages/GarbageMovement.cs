using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class GarbageMovement 
    {
        public void Move(float duration, Vector3 target, Garbage garbage)
        {
            garbage.Transform.DOLocalJump(target,1F, 1, duration);
        }

        public void Jump(Vector3 position, Rigidbody rigidbody, float force)
        {
            rigidbody.AddForce(position * force, ForceMode.Impulse);
        }

        public void Rotate(Rigidbody rigidbody, float rotationSpeed)
        {
            rigidbody.AddTorque(rigidbody.transform.right * rotationSpeed, ForceMode.Impulse);
        }
    }
}