using System;
using CodeBase.Gameplay.NatureDamageables;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class DamageNatureOnTrigger : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        private NatureHurtable _natureHurtable;

        private void Awake()
        {
            _natureHurtable = GetComponent<NatureHurtable>();
        }

        private void OnEnable()
        {
            TriggerObserver.TriggerEntered += OnTriggerEntered;
        }

        private void OnDisable()
        {
            TriggerObserver.TriggerEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out NatureDamageable natureDamageable))
                return;

            _natureHurtable.Hurt(natureDamageable);
        }
    }
}