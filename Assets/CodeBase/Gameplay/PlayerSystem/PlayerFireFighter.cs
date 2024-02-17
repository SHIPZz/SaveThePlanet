using System;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Gameplay.Fireables;
using CodeBase.Gameplay.Pickeables;
using CodeBase.Services.TriggerObserves;
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
            TriggerObserver.TriggerEntered += OnFireDetected;
        }

        public void OnDisable()
        {
            _playerHandContainer.Set -= OnPlayerPickedUp;
            TriggerObserver.TriggerEntered -= OnFireDetected;
        }

        private void OnFireDetected(Collider collision)
        {
            if(!collision.gameObject.TryGetComponent(out Fireable fireable))
                return;

            if (_fireExtinguishable == null)
                return;
            
            _playerHandContainer.Pickeable.Drop();
            _fireExtinguishable.SetPutOut(fireable.transform.position, fireable.transform.up * -1);
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