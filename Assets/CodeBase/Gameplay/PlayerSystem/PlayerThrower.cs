using System;
using CodeBase.Gameplay.Pickeables;
using CodeBase.Gameplay.SoundPlayer;
using CodeBase.Gameplay.Throwables;
using CodeBase.Services.StaticData;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerThrower : MonoBehaviour
    {
        public SoundPlayerSystem SoundPlayerSystem;

        public Transform CameraPivot;
        private Pickeable _pickeable;
        private PlayerHandContainer _playerHandContainer;
        private GameStaticDataService _gameStaticDataService;
        private float _leftClickThrowSpeed;
        private float _rightClickThrowSpeed;

        public event Action Thrown;

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
            _pickeable = _playerHandContainer.Pickeable;

            if (_pickeable == null)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                TryThrow(_leftClickThrowSpeed);
            }

            if (Input.GetMouseButtonDown(1))
            {
                TryThrow(_rightClickThrowSpeed);
            }
        }

        private void TryThrow(float speed)
        {
            if (!_pickeable.gameObject.TryGetComponent(out Throwable throwable))
                return;

            _pickeable.Drop();
            throwable.Throw(CameraPivot.forward, speed);

            _playerHandContainer.Clear();
            
            Thrown?.Invoke();
        }
    }
}