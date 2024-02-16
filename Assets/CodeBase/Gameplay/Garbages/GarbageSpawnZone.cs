using System;
using System.Collections.Generic;
using CodeBase.Services.Factories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.Garbages
{
    public class GarbageSpawnZone : MonoBehaviour
    {
        [SerializeField] private int _count = 10;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private int _targetSpawnCount = 1;

        public bool HasGarbages { get; private set; }

        private int _spawnedCount;
        private GameFactory _gameFactory;
        private List<Garbage> _spawnedGarbages = new();

        public event Action GarbagesDestroyed;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void OnDisable()
        {
            foreach (Garbage garbage in _spawnedGarbages)
            {
                if (garbage != null)
                    garbage.Destroyed -= OnGarbageDestroyed;
            }
        }

        [Button]
        public void Spawn()
        {
            for (int i = 0; i < _count; i++)
            {
                Garbage garbage = _gameFactory
                    .CreateRandomGarbage(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position, transform,
                        Quaternion.identity);

                garbage.Destroyed += OnGarbageDestroyed;
                _spawnedGarbages.Add(garbage);
            }

            HasGarbages = true;
        }

        private void OnGarbageDestroyed(Garbage garbage)
        {
            garbage.Destroyed -= OnGarbageDestroyed;
            _spawnedCount = Mathf.Clamp(_spawnedGarbages.Count - 1, 0, _spawnedGarbages.Count);
            _spawnedGarbages.Remove(garbage);

            if (_spawnedCount <= 0)
            {
                GarbagesDestroyed?.Invoke();
                HasGarbages = false;
            }
        }
    }
}