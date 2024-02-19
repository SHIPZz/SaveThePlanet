using System;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class SpawnDestroyablePartOnDestroy : MonoBehaviour
    {
        private DestroyableObject _destroyableObject;
        private GameFactory _gameFactory;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _destroyableObject = GetComponent<DestroyableObject>();
        }

        private void OnEnable()
        {
            _destroyableObject.Destroyed += Spawn;
        }

        private void OnDisable()
        {
            _destroyableObject.Destroyed -= Spawn;
        }

        private void Spawn()
        {
            DestroyableObjectPart destroyablePart = _gameFactory.Create(_destroyableObject.DestroyableTypeId, null, transform.position, transform.rotation);
            destroyablePart.Activate();
        }
    }
}