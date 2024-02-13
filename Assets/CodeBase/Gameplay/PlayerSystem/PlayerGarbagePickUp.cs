using System;
using CodeBase.Constant;
using CodeBase.Gameplay.SoundPlayer;
using CodeBase.Services.TriggerObserve;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerGarbagePickUp : PlayerPickUp
    {
        public Transform Anchor;
        public SoundPlayerSystem SoundPlayerSystem;
        public TriggerObserver GarbageObserver;
        public Vector3 Offset;
        
        private bool _hasItem;
        private ITakeable _takeable;
        private PlayerHandContainer _playerHandContainer;

        [Inject]
        private void Construct(PlayerHandContainer playerHandContainer) => 
            _playerHandContainer = playerHandContainer;

        private void Start() => 
            _playerHandContainer.Cleared += OnCleared;

        protected override void OnDisable()
        {
            base.OnDisable();
            _playerHandContainer.Cleared -= OnCleared;
        }

        protected override void PickUp(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out ITakeable takeable))
                return;

            if (_hasItem)
                return;

            _hasItem = true;
            _takeable = takeable;
            _takeable.Transform.gameObject.layer = LayerId.IgnorePlayer;

            if (collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
                Destroy(rigidbody);

            _takeable.Transform.parent = Anchor;
            _takeable.Transform.localPosition = Offset;
            _takeable.Transform.localRotation = Quaternion.identity;
            SoundPlayerSystem.PlayActiveSound();
            _playerHandContainer.TrySetCurrentObject(_takeable);
        }

        private void OnCleared()
        {
            _hasItem = false;
            _takeable = null;
        }
    }
}