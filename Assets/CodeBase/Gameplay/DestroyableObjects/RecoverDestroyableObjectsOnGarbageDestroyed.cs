using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.Services.Factories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class RecoverDestroyableObjectsOnGarbageDestroyed : MonoBehaviour
    {
        public List<DestroyableObject> DestroyableObjects;
        public GarbageSpawnZone GarbageSpawnZone;

        private GameFactory _gameFactory;

        private Dictionary<int, DestroyableTypeId> _instanceIdToDestroyableTypeId = new();

        private Dictionary<int, Vector3> _cachedPositions = new();
        private Dictionary<int, Quaternion> _cachedRotations = new();

        public event Action<DestroyableObject> Recovered;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            foreach (DestroyableObject destroyableObject in DestroyableObjects)
            {
                int instanceId = destroyableObject.gameObject.GetInstanceID();
                _instanceIdToDestroyableTypeId[instanceId] = destroyableObject.DestroyableTypeId;
                _cachedPositions[instanceId] = destroyableObject.transform.position;
                _cachedRotations[instanceId] = destroyableObject.transform.rotation;
            }
        }

        private void OnEnable() =>
            GarbageSpawnZone.GarbagesDestroyed += Recover;

        private void OnDisable() =>
            GarbageSpawnZone.GarbagesDestroyed -= Recover;

        [Button]
        private void Recover()
        {
            foreach (KeyValuePair<int, DestroyableTypeId> pair in _instanceIdToDestroyableTypeId)
            {
                Vector3 position = _cachedPositions[pair.Key];
                Quaternion rotation = _cachedRotations[pair.Key];
                DestroyableObject destroyableObject = _gameFactory.CreateDestroyableObject(pair.Value, null, position, rotation);
                Recovered?.Invoke(destroyableObject);
            }
        }
    }
}