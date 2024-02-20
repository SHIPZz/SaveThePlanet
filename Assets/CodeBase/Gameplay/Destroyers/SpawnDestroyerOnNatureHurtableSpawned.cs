using System;
using CodeBase.Enums;
using CodeBase.Gameplay.NatureHurtables;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Destroyers
{
    public class SpawnDestroyerOnNatureHurtableSpawned : MonoBehaviour
    {
        public NatureHurtableSpawner NatureHurtableSpawner;
        public DestroyerType DestroyerType;
        
        private GameFactory _gameFactory;
        private Destroyer _destroyer;

        [Inject]
        private void Construct(GameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void OnEnable() => 
            NatureHurtableSpawner.Spawned += Spawn;

        private void OnDisable() => 
            NatureHurtableSpawner.Spawned -= Spawn;

        private void Spawn() => 
            _gameFactory.Create(DestroyerType, transform, transform.position, Quaternion.identity);
    }
}