using System;
using System.Collections;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Fireables
{
    public class FireableSpawner : MonoBehaviour
    {
        public FireableType FireableType;
        public float StartSpawnDelay = 3f;
        public float SpawnDelay = 300f;

        private GameFactory _gameFactory;
        private Fireable _fireable;
        private Coroutine _coroutine;

        public event Action Spawned;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(StartSpawnDelay);
            Spawn();
        }

        private void OnDisable()
        {
            if (_fireable != null)
                _fireable.OnPutOut -= StartNewCoroutine;
        }

        private void StartNewCoroutine()
        {
            _fireable = null;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(SpawnDelay);
            Spawn();
        }

        private void Spawn()
        {
            _fireable = _gameFactory.Create(FireableType, null, transform.position, transform.rotation);
            _fireable.OnPutOut += StartNewCoroutine;
            Spawned?.Invoke();
        }
    }
}