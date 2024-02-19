using System;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class SetOwnerOnPickUp : MonoBehaviour
    {
        public event Action NewOwnerSet;
        public event Action OwnerNullSet;
        
        private Pickeable _pickeable;

        private void Awake()
        {
            _pickeable = GetComponent<Pickeable>();
        }

        private void OnEnable()
        {
            _pickeable.OnPickedUp += SetOwner;
            _pickeable.OnDropped += SetOwner;
        }

        private void OnDisable()
        {
            _pickeable.OnPickedUp -= SetOwner;
            _pickeable.OnDropped -= SetOwner;
        }

        private void SetOwner(Transform parent)
        {
            transform.parent = parent;
            
            if(parent != null)
                NewOwnerSet?.Invoke();
            else
                OwnerNullSet?.Invoke();
        }
    }
}