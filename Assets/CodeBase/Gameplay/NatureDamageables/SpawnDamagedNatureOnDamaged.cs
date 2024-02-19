using System;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.NatureDamageables
{
    public class SpawnDamagedNatureOnDamaged : MonoBehaviour
    {
        public DamagedNatureType DamagedNatureType;

        private NatureDamageable _natureDamageable;
        private GameFactory _gameFactory;
        private DamagedNature _damagedNature;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _natureDamageable = GetComponent<NatureDamageable>();
        }

        private void OnEnable()
        {
            _natureDamageable.Damaged += Spawn;
            _natureDamageable.Recovered += DestroySpawnedDamagedNature;
        }

        private void OnDisable()
        {
            _natureDamageable.Damaged -= Spawn;
            _natureDamageable.Recovered -= DestroySpawnedDamagedNature;
        }

        private void DestroySpawnedDamagedNature()
        {
            Destroy(_damagedNature.gameObject);
        }

        private void Spawn()
        {
            _damagedNature = _gameFactory.Create(DamagedNatureType, null, transform.position, transform.rotation);
        }
    }
}