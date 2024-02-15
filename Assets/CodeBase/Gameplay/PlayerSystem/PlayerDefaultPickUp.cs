using System;
using CodeBase.Constant;
using CodeBase.Gameplay.Pickeables;
using CodeBase.Gameplay.SoundPlayer;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerDefaultPickUp : PlayerPickUp
    {
        public Transform Anchor;
        public SoundPlayerSystem SoundPlayerSystem;
        public Vector3 Offset;
        
        private Pickeable _pickeable;
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
            if (!collision.gameObject.TryGetComponent(out Pickeable pickeable))
                return;

            if (_playerHandContainer.HasItem)
                return;
            
            pickeable.PickUp(transform);
            _playerHandContainer.TrySetCurrentObject(pickeable);
        }

        private void OnCleared()
        {
            _pickeable = null;
        }
    }
}