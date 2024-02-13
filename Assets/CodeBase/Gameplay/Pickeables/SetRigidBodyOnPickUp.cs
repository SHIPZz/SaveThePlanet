using System;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class SetRigidBodyOnPickUp : MonoBehaviour
    {
        public RigidbodyInterpolation RigidbodyInterpolation;
        public CollisionDetectionMode CollisionDetectionMode;
        
        private Pickeable _pickeable;

        private void Awake() => 
            _pickeable = GetComponent<Pickeable>();

        private void OnEnable()
        {
            _pickeable.OnPickedUp += DestroyRb;
            _pickeable.OnDropped += AddRb;
        }

        private void OnDisable()
        {
            _pickeable.OnPickedUp -= DestroyRb;
            _pickeable.OnDropped -= AddRb;
        }

        private void DestroyRb(Transform obj)
        {
            var rb = GetComponent<Rigidbody>();

            if (rb != null)
                Destroy(rb);
        }

        private void AddRb(Transform obj)
        {
            gameObject.AddComponent<Rigidbody>();
            var rb = GetComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode;
            rb.interpolation = RigidbodyInterpolation;
        }
    }
}