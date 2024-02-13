using System;
using CodeBase.Gameplay.SoundPlayer;
using CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerThrower : MonoBehaviour
    {
        public SoundPlayerSystem SoundPlayerSystem;
    
        public Transform CameraPivot;
        private ITakeable _takeable;
        private PlayerHandContainer _playerHandContainer;
        private GameStaticDataService _gameStaticDataService;
        private float _leftClickThrowSpeed;
        private float _rightClickThrowSpeed;

        [Inject]
        private void Construct(PlayerHandContainer playerHandContainer, GameStaticDataService gameStaticDataService)
        {
            _gameStaticDataService = gameStaticDataService;
            _playerHandContainer = playerHandContainer;
        }

        private void Start()
        {
            _leftClickThrowSpeed = _gameStaticDataService.GetPlayerData().ThrowLeftClickSpeed;
            _rightClickThrowSpeed = _gameStaticDataService.GetPlayerData().ThrowRightClickSpeed;
        }

        private void Update()
        {
            _takeable = _playerHandContainer.Takeable;

            if (_takeable == null)
                return;

            if (Input.GetMouseButton(0) && _takeable is IThrowable)
            {
                Throw(_leftClickThrowSpeed);
            }

            if (Input.GetMouseButton(1) && _takeable is IThrowable)
            {
                Throw(_rightClickThrowSpeed);
            }
        }

        private void Throw(float speed)
        {
            _takeable.Transform.parent = null;
            var throwable = _takeable as IThrowable;
            var throwableCollider = throwable.Transform.GetComponent<Collider>();
            throwable.Transform.gameObject.AddComponent<Rigidbody>();

            var throwableRb = throwable.Transform.GetComponent<Rigidbody>();
            throwableRb.interpolation = RigidbodyInterpolation.Interpolate;
            throwableRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            throwableRb.AddForce(CameraPivot.forward * speed, ForceMode.Impulse);
            SoundPlayerSystem.PlayActiveSound();
            throwable.SetRotation();
            throwableCollider.enabled = true;

            _playerHandContainer.Clear();
            _takeable = null;
        }
    }
}