using System;
using CodeBase.Services.TriggerObserve;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerFireFighter : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        
        private PlayerHandContainer _playerHandContainer;
        private IFireExtinguishable _fireExtinguishable;

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
            
            _fireExtinguishable.Anchor.SetParent(null);
            _fireExtinguishable.MoveTo(fireable.Anchor.position, _fireExtinguishable.PutOut);
            _fireExtinguishable.RotateTo(fireable.Anchor.up * -1);
            _fireExtinguishable = null;
            _playerHandContainer.Clear();
        }

        private void OnPlayerPickedUp(ITakeable takeable)
        {
            if (takeable is IFireExtinguishable extinguishable)
            {
                _fireExtinguishable = extinguishable;
                return;
            }

            _fireExtinguishable = null;
        }
    }
}