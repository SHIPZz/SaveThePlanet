using System;
using CodeBase.Enums;
using CodeBase.Gameplay.Recoverables;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.NatureDamageables
{
    public class SpawnDamagedNatureOnDamaged : MonoBehaviour, IRecoverableEvent
    {
        public DamagedNatureType DamagedNatureType;

        private Damageable _damageable;
        private GameFactory _gameFactory;
        private DamagedNature _damagedNature;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _damageable = GetComponent<Damageable>();
        }

        private void OnEnable()
        {
            _damageable.Damaged += Spawn;
        }

        private void OnDisable()
        {
            _damageable.Damaged -= Spawn;
        }

        public void OnRecovered()
        {
            Destroy(_damagedNature.gameObject);
        }

        private void Spawn()
        {
            _damagedNature = _gameFactory.Create(DamagedNatureType, null, transform.position, transform.rotation);
        }
    }
}