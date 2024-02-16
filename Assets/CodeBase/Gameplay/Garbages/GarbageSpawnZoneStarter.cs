using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class GarbageSpawnZoneStarter : MonoBehaviour
    {
        public float SpawnDelay = 300f;

        private GarbageSpawnZone _garbageSpawnZone;
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            _garbageSpawnZone = GetComponent<GarbageSpawnZone>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(SpawnDelay);
            _spawnCoroutine = StartCoroutine(InitSpawnCoroutine());
        }

        private void OnEnable()
        {
            _garbageSpawnZone.GarbagesDestroyed += StartNewCoroutine;
        }

        private void OnDisable()
        {
            _garbageSpawnZone.GarbagesDestroyed -= StartNewCoroutine;
        }

        private void StartNewCoroutine()
        {
            if (_spawnCoroutine != null)
                StopCoroutine(_spawnCoroutine);

            _spawnCoroutine = StartCoroutine(InitSpawnCoroutine());
        }

        private IEnumerator InitSpawnCoroutine()
        {
            yield return new WaitForSeconds(SpawnDelay);
            _garbageSpawnZone.Spawn();
        }
    }
}