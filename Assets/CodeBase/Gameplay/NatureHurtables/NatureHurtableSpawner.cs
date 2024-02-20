using System;
using System.Collections;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class NatureHurtableSpawner : MonoBehaviour
    {
        public NatureHurtableType HurtableType;
        public float SpawnDelay;
        public float SpawnStartDelay = 3f;

        private GameFactory _gameFactory;
        private NatureHurtable _hurtableNature;
        private Coroutine _coroutine;

        public event Action Spawned;

        [Inject]
        private void Construct(GameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(SpawnStartDelay);
            Spawn();
        }

        private void OnDisable()
        {
            if (_hurtableNature != null)
                _hurtableNature.Destroyed -= StartNewCoroutine;
        }

        private IEnumerator StartSpawnCoroutine()
        {
            yield return new WaitForSeconds(SpawnDelay);
            Spawn();
        }

        [Button]
        private void StartNewCoroutine()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(StartSpawnCoroutine());
        }

        private void Spawn()
        {
            _hurtableNature = _gameFactory.Create(HurtableType, transform, Vector3.zero, Quaternion.identity);
            _hurtableNature.transform.localPosition = Vector3.zero;
            _hurtableNature.transform.localRotation = Quaternion.identity;
            _hurtableNature.Destroyed += StartNewCoroutine;
            Spawned?.Invoke();
        }
    }
}