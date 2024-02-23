using CodeBase.Constant;
using CodeBase.Gameplay.Camera;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Services.Factories;
using CodeBase.Services.Providers.CameraProviders;
using CodeBase.Services.Providers.LocationProviders;
using CodeBase.Services.Providers.PlayerProviders;
using UnityEngine;
using Zenject;

namespace CodeBase.EntryPointSystem
{
    public class EntryPoint : IInitializable
    {
        private readonly LocationProvider _locationProvider;
        private readonly GameFactory _gameFactory;
        private readonly CameraProvider _cameraProvider;
        private readonly PlayerProvider _playerProvider;

        public EntryPoint(LocationProvider locationProvider, GameFactory gameFactory, CameraProvider cameraProvider, PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _cameraProvider = cameraProvider;
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
        }

        public void Initialize()
        {
            Player player = CreatePlayer();
            _playerProvider.Player = player;
            _cameraProvider.Camera = player.GetComponentInChildren<Camera>();
            _cameraProvider.CameraFollower = _cameraProvider.Camera.GetComponent<CameraFollower>();
        }

        private Player CreatePlayer()
        {
            return _gameFactory.Create<Player>(_locationProvider.PlayerSpawnPoint,
                _locationProvider.PlayerSpawnPoint.position,
                Quaternion.identity, AssetPath.Player);
        }
    }
}