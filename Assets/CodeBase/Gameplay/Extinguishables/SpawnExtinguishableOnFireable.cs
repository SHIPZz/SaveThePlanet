using System;
using CodeBase.Enums;
using CodeBase.Gameplay.Fireables;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Extinguishables
{
    public class SpawnExtinguishableOnFireable : MonoBehaviour
    {
        public FireableSpawner FireableSpawner;
        public ExtinguishableType ExtinguishableType;
        
        private GameFactory _gameFactory;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        private void OnEnable()
        {
            FireableSpawner.Spawned += Spawn;
        }

        private void OnDisable()
        {
            FireableSpawner.Spawned -= Spawn;
        }

        private void Spawn()
        {
            _gameFactory.Create(ExtinguishableType, null, transform.position, transform.rotation);
        }
    }
}