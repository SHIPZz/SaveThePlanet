using CodeBase.Constant;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Services.Factories;
using CodeBase.Services.Providers.LocationProviders;
using UnityEngine;
using Zenject;

namespace CodeBase.EntryPointSystem
{
    public class EntryPoint : IInitializable
    {
        private readonly LocationProvider _locationProvider;
        private readonly GameFactory _gameFactory;

        public EntryPoint(LocationProvider locationProvider, GameFactory gameFactory)
        {
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
        }

        public void Initialize()
        {
            Player player = CreatePlayer();
            // Camera camera = CreateCamera();
            // InitCamera(camera, player);
        }

        private void InitCamera(Camera camera, Player player) => 
            camera.GetComponent<CameraFollower>().SetTarget(player.transform);

        private Camera CreateCamera()
        {
            return _gameFactory.Create<Camera>(_locationProvider.PlayerSpawnPoint,
                _locationProvider.PlayerSpawnPoint.position,
                Quaternion.identity, AssetPath.Camera);
        }

        private Player CreatePlayer()
        {
            return _gameFactory.Create<Player>(_locationProvider.PlayerSpawnPoint,
                _locationProvider.PlayerSpawnPoint.position,
                Quaternion.identity, AssetPath.Player);
        }
    }
}