using System;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Gameplay.Pickeables;
using CodeBase.Services.TriggerObserve;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerFireFighter : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        
        private PlayerHandContainer _playerHandContainer;
        private Extinguishable _fireExtinguishable;

        [Inject]
        private void Construct(PlayerHandContainer playerHandContainer) => 
            _playerHandContainer = playerHandContainer;

        public void OnEnable()
        {
            _playerHandContainer.Set += OnPlayerPickedUp;
            TriggerObserver.CollisionEntered += OnFireDetected;
        }

        public void OnDisable()
        {
            _playerHandContainer.Set -= OnPlayerPickedUp;
            TriggerObserver.CollisionEntered -= OnFireDetected;
        }

        private void OnFireDetected(Collision collision)
        {
            if(!collision.gameObject.TryGetComponent(out IFireable fireable))
                return;

            if (_fireExtinguishable == null)
                return;
            
            _playerHandContainer.Pickeable.Drop();
            _fireExtinguishable.SetPutOut(fireable.Anchor.position, fireable.Anchor.up * -1);
            _fireExtinguishable = null;
            _playerHandContainer.Clear();
        }

        private void OnPlayerPickedUp(Pickeable pickeable)
        {
            if (pickeable.TryGetComponent(out Extinguishable extinguishable))
            {
                _fireExtinguishable = extinguishable;
                return;
            }

            _fireExtinguishable = null;
        }
    }
}