using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Services.Providers.Asset;
using CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factories
{
    public class GameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private GameStaticDataService _gameStaticDataService;

        public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider, GameStaticDataService gameStaticDataService)
        {
            _gameStaticDataService = gameStaticDataService;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public DestroyableObjectPart Create(DestroyableTypeId destroyableTypeId, Transform parent, Vector3 at, Quaternion rotation)
        {
            DestroyableObjectPart prefab = _gameStaticDataService.Get(destroyableTypeId);

            return _instantiator.InstantiatePrefabForComponent<DestroyableObjectPart>(prefab, at, rotation,parent);
        }
        
        public T Create<T>(Transform parent, Vector3 at, Quaternion rotation, string path) where T : Component
        {
            var prefab = _assetProvider.Get<T>(path);

            return _instantiator.InstantiatePrefabForComponent<T>(prefab, at, rotation,parent);
        }
    }
}