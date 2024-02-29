using CodeBase.Constant;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Services.Factories;
using CodeBase.Services.Providers.CameraProviders;
using CodeBase.Services.Providers.LocationProviders;
using CodeBase.Services.Providers.PlayerProviders;
using CodeBase.Services.UI;
using CodeBase.UI.Camera;
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
        private UIService _uiService;

        public EntryPoint(LocationProvider locationProvider,
            GameFactory gameFactory,
            CameraProvider cameraProvider,
            PlayerProvider playerProvider, 
            UIService uiService)
        {
            _uiService = uiService;
            _playerProvider = playerProvider;
            _cameraProvider = cameraProvider;
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
        }

        public void Initialize()
        {
            Player player = CreatePlayer();
            _playerProvider.Player = player;
            InitializeCamera(player);
        }

        private void InitializeCamera(Player player)
        {
            var cameraContainer = player.GetComponent<CameraContainer>();
            _cameraProvider.Camera = cameraContainer.Camera;
            _cameraProvider.CameraFollower = cameraContainer.CameraFollower;
            _cameraProvider.CameraParticle = cameraContainer.ParticleCamera;
            _cameraProvider.CameraPivot = cameraContainer.CameraPivot;
        }

        private Player CreatePlayer()
        {
            return _gameFactory.Create<Player>(_locationProvider.PlayerSpawnPoint,
                _locationProvider.PlayerSpawnPoint.position,
                Quaternion.identity, AssetPath.Player);
        }
    }
}