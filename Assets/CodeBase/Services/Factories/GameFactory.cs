using System.Collections.Generic;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Gameplay.Destroyers;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Gameplay.Fireables;
using CodeBase.Gameplay.GarbageDetection;
using CodeBase.Gameplay.Garbages;
using CodeBase.Gameplay.NatureDamageables;
using CodeBase.Gameplay.NatureHurtables;
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
        private readonly GameStaticDataService _gameStaticDataService;

        public GameFactory(IInstantiator instantiator, IAssetProvider assetProvider, GameStaticDataService gameStaticDataService)
        {
            _gameStaticDataService = gameStaticDataService;
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public DestroyableObjectPart Create(DestroyableTypeId destroyableTypeId, Transform parent, Vector3 at,
            Quaternion rotation)
        {
            DestroyableObjectPart prefab = _gameStaticDataService.Get(destroyableTypeId);

            return _instantiator.InstantiatePrefabForComponent<DestroyableObjectPart>(prefab, at, rotation, parent);
        }

        public DamagedNature Create(DamagedNatureType damagedNatureType, Transform parent, Vector3 at,
            Quaternion rotation)
        {
            DamagedNature prefab = _gameStaticDataService.Get(damagedNatureType);

            return _instantiator.InstantiatePrefabForComponent<DamagedNature>(prefab, at, rotation, parent);
        }

        public GarbageDeathable Create(string id, Transform parent, Vector3 at, Quaternion rotation)
        {
            GarbageDeathable prefab = _gameStaticDataService.Get(id);

            return _instantiator.InstantiatePrefabForComponent<GarbageDeathable>(prefab, at, rotation, parent);
        }

        public Garbage CreateRandomGarbage(Vector3 at, Transform parent, Quaternion rotation)
        {
            List<Garbage> garbages = _gameStaticDataService.GetAllGarbages();

            Garbage randomGarbagePrefab = garbages[Random.Range(0, garbages.Count)];

            return _instantiator.InstantiatePrefabForComponent<Garbage>(randomGarbagePrefab, at, rotation, parent);
        }
        
        public Fireable Create(FireableType fireableType, Transform parent, Vector3 position, Quaternion rotation)
        {
            Fireable prefab = _gameStaticDataService.Get(fireableType);

            return _instantiator.InstantiatePrefabForComponent<Fireable>(prefab, position, rotation, parent);
        }
        
        public Extinguishable Create(ExtinguishableType id, Transform parent, Vector3 position, Quaternion rotation)
        {
            Extinguishable prefab = _gameStaticDataService.Get(id);

            return _instantiator.InstantiatePrefabForComponent<Extinguishable>(prefab, position, rotation, parent);
        }

        public T Create<T>(Transform parent, Vector3 at, Quaternion rotation, string path) where T : Component
        {
            var prefab = _assetProvider.Get<T>(path);

            return _instantiator.InstantiatePrefabForComponent<T>(prefab, at, rotation, parent);
        }

        public NatureHurtable Create(NatureHurtableType destroyableTypeId, Transform parent, Vector3 position, Quaternion rotation)
        {
            NatureHurtable prefab = _gameStaticDataService.Get(destroyableTypeId);

            return _instantiator.InstantiatePrefabForComponent<NatureHurtable>(prefab, position, rotation, parent);
        }

        public Destroyer Create(DestroyerType destroyerTypeId, Transform parent, Vector3 position, Quaternion rotation)
        {
            Destroyer prefab = _gameStaticDataService.Get(destroyerTypeId);

            return _instantiator.InstantiatePrefabForComponent<Destroyer>(prefab, position, rotation, parent);
        }
    }
}