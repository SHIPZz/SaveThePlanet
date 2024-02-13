using System;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class Pickeable : MonoBehaviour
    {
        public Transform CurrentParent { get; private set; }
        public bool IsPickedUp { get; private set; }
        public event Action<Transform> OnPickedUp;
        public event Action<Transform> OnMovementPickedUp;
        public event Action<Transform> OnDropped;

        public void PickUpWithMovement(Transform parent)
        {
            if(!PickUp(parent))
                return;
                
            OnMovementPickedUp?.Invoke(parent);
        }

        public bool PickUp(Transform parent)
        {
            if(IsPickedUp)
                return false;
            
            CurrentParent = parent;
            IsPickedUp = true;
            OnPickedUp?.Invoke(CurrentParent);
            return true;
        }

        public void Drop()
        {
            if(!IsPickedUp)
                return;

            CurrentParent = null;
            IsPickedUp = false;
            OnDropped?.Invoke(CurrentParent);
        }
    }
}