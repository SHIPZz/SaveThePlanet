using System;
using CodeBase.Gameplay.CleanUpSystem;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class SpawnDestroyablePartOnDestroy : MonoBehaviour,ICleanUp
    {
        private DestroyableObject _destroyableObject;
        private GameFactory _gameFactory;

        [Inject]
        private void Construct(GameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void Awake() => 
            _destroyableObject = GetComponent<DestroyableObject>();

        public void CleanUp()
        {
            Spawn();
        }

        private void Spawn()
        {
            DestroyableObjectPart destroyablePart = _gameFactory.Create(_destroyableObject.DestroyableTypeId, null, transform.position, transform.rotation);
            destroyablePart.Activate();
        }
    }
}