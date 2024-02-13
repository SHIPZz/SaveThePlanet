using System;
using CodeBase.Services.TriggerObserve;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class CampFireMediator : MonoBehaviour
    {
        public TriggerObserver PlayerObserver;
        public TriggerObserver ExtinguisherObserver;

        private CampFire _campFire;
        private IFireExtinguishable _extinguishable;

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
            if(!collider.gameObject.TryGetComponent(out IFireExtinguishable fireExtinguishable))
                return;
            
            _extinguishable = null;
        }

        private void OnExtinguisherEntered(Collider collider)
        {
            if(!collider.gameObject.TryGetComponent(out IFireExtinguishable fireExtinguishable))
                return;

            _extinguishable = fireExtinguishable;
            _extinguishable.Done += OnPutOut;
        }

        private void OnPutOut(IFireExtinguishable extinguishable)
        {
            _campFire.Disable();
            _extinguishable.Done -= OnPutOut;
        }
    }
}