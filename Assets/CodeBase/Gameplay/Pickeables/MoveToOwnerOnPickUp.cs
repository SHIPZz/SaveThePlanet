using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class MoveToOwnerOnPickUp : MonoBehaviour
    {
        public float MovementSpeed = 0.5F;
        public float JumpPower = 1f;
        public int NumJumps = 1;
        
        public event Action Moved;
        
        private Pickeable _pickeable;
        private List<Vector3> _points;

        private void Awake()
        {
            _pickeable = GetComponent<Pickeable>();
        }

        private void OnEnable() => 
            _pickeable.OnMovementPickedUp += Move;

        private void OnDisable() => 
            _pickeable.OnMovementPickedUp -= Move;

        private void Move(Transform obj)
        {
            Moved?.Invoke();
            
            transform.DOLocalJump(Vector3.zero, JumpPower, NumJumps, MovementSpeed);
        }
    }
}