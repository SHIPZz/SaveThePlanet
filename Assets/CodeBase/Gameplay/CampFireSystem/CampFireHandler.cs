using System;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Services.TriggerObserve;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class CampFireHandler : MonoBehaviour
    {
        public TriggerObserver PlayerObserver;
        public TriggerObserver ExtinguisherObserver;

        private CampFire _campFire;
        private Extinguishable _extinguishable;

        private void Awake() => 
            _campFire = GetComponent<CampFire>();

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
            if(!collider.gameObject.TryGetComponent(out Extinguishable fireExtinguishable))
                return;

            _extinguishable = fireExtinguishable;
            _extinguishable.Finished +=  _campFire.Disable;
        }
    }
}