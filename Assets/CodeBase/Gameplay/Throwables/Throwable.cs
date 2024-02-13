using System;
using UnityEngine;

namespace CodeBase.Gameplay.Throwables
{
    public class Throwable : MonoBehaviour
    {
        public event Action ThrowStarted;
        public event Action Thrown;
        
        public void Throw(Vector3 target, float force)
        {
            ThrowStarted?.Invoke();
            var throwableRb = GetComponent<Rigidbody>();
            throwableRb.AddForce(target * force, ForceMode.Impulse);
            Thrown?.Invoke();
        }
    }
}