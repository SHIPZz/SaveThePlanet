using CodeBase.Constant;
using CodeBase.Gameplay.PlayerSystem;
using CodeBase.Services.Providers.Asset;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factories
{
    public class GameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public T Create<T>(Transform parent, Vector3 at, Quaternion rotation, string path) where T : Component
        {
            var prefab = _assetProvider.Get<T>(path);

            return _instantiator.InstantiatePrefabForComponent<T>(prefab, at, rotation,parent);
        }
    }
}