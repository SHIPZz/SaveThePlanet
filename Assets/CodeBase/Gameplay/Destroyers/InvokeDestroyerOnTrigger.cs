using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.Destroyers
{
    public class InvokeDestroyerOnTrigger : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        private Destroyer _destroyer;

        private void Awake()
        {
            _destroyer = GetComponent<Destroyer>();
        }

        private void OnEnable()
        {
            TriggerObserver.TriggerEntered += InvokeDestroy;
        }

        private void OnDisable()
        {
            TriggerObserver.TriggerEntered -= InvokeDestroy;
        }

        private void InvokeDestroy(Collider collider)
        {
            if (!collider.gameObject.TryGetComponent(out DestroyableObject destroyableObject))
                return;

            _destroyer.Destroy(destroyableObject);
        }
    }
}