using System;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Gameplay.Fireables;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class PutOutOnExtinguishable : MonoBehaviour
    {
        public TriggerObserver ExtinguisherObserver;

        private Fireable _fireable;
        private Extinguishable _extinguishable;

        private void Awake() => 
            _fireable = GetComponent<Fireable>();

        private void OnEnable()
        {
            ExtinguisherObserver.TriggerEntered += OnExtinguisherEntered;
            ExtinguisherObserver.TriggerExited += OnExtinguisherExited;
        }

        private void OnDisable()
        {
            ExtinguisherObserver.TriggerEntered -= OnExtinguisherEntered;
            ExtinguisherObserver.TriggerExited -= OnExtinguisherExited;
        }

        private void OnExtinguisherExited(Collider collider)
        {
            if(!collider.gameObject.TryGetComponent(out Extinguishable fireExtinguishable))
                return;
            
            _extinguishable = null;
        }

        private void OnExtinguisherEntered(Collider collider)
        {
            print(collider.gameObject.name);
            if(!collider.gameObject.TryGetComponent(out Extinguishable fireExtinguishable))
                return;

            _extinguishable = fireExtinguishable;
            _extinguishable.Finished +=  _fireable.PutOut;
        }
    }
}