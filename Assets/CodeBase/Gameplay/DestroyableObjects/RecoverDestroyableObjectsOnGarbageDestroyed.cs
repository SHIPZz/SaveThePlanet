using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class RecoverDestroyableObjectsOnGarbageDestroyed : MonoBehaviour
    {
        public List<DestroyableObject> DestroyableObjects;
        public GarbageSpawnZone GarbageSpawnZone;

        private GameFactory _gameFactory;
        private Dictionary<DestroyableTypeId, Vector3> _cachedPositions = new();
        private Dictionary<DestroyableTypeId, Quaternion> _cachedRotations = new();

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            foreach (DestroyableObject destroyableObject in DestroyableObjects)
            {
                _cachedPositions[destroyableObject.DestroyableTypeId] = destroyableObject.transform.position;
                _cachedRotations[destroyableObject.DestroyableTypeId] = destroyableObject.transform.rotation;
            }
        }

        private void OnEnable()
        {
            GarbageSpawnZone.GarbagesDestroyed += Recover;
        }

        private void OnDisable()
        {
            GarbageSpawnZone.GarbagesDestroyed -= Recover;
        }

        private void Recover()
        {
            foreach (KeyValuePair<DestroyableTypeId, Vector3> keyValuePair in _cachedPositions)
            {
                _gameFactory.CreateDestroyableObject(keyValuePair.Key, null, keyValuePair.Value,
                    _cachedRotations[keyValuePair.Key]);
            }
        }
    }
}