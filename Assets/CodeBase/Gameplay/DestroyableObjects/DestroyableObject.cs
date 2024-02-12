using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class DestroyableObject : MonoBehaviour
    {
        public DestroyableTypeId DestroyableTypeId;
        
        private GameFactory _gameFactory;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent(out Garbage garbage))
                return;
            
            DestroyableObjectPart destroyablePart = _gameFactory.Create(DestroyableTypeId, null, transform.position, transform.rotation);
            destroyablePart.Activate();
            Destroy(gameObject);
        }
    }
}