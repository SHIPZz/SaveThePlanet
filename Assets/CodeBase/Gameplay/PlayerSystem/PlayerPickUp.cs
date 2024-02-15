using System;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.PlayerSystem
{
    public abstract class PlayerPickUp : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        private void OnEnable() => 
            TriggerObserver.CollisionEntered += PickUp;

        protected virtual void OnDisable() => 
            TriggerObserver.CollisionEntered -= PickUp;

        protected abstract void PickUp(Collision collision);
    }
}