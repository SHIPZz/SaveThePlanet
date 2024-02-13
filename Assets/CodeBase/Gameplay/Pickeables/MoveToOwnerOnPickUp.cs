using System;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class MoveToOwnerOnPickUp : MonoBehaviour
    {
        public float MovementSpeed = 0.5F;
        public event Action Moved;
        
        private Pickeable _pickeable;

        private void Awake() => 
            _pickeable = GetComponent<Pickeable>();

        private void OnEnable() => 
            _pickeable.OnMovementPickedUp += Move;

        private void OnDisable() => 
            _pickeable.OnMovementPickedUp -= Move;

        private void Move(Transform obj)
        {
            Moved?.Invoke();
            transform.DOLocalJump(Vector3.zero, 1f, 1, MovementSpeed);
        }
    }
}