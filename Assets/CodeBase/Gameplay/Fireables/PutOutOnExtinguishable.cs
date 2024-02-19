using System;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Gameplay.Fireables;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class PutOutOnExtinguishable : MonoBehaviour
    {
        private Fireable _fireable;
        private Extinguishable _extinguishable;

        private void Awake() => 
            _fireable = GetComponent<Fireable>();
        
        
        private void OnTriggerExit(Collider collider)
        {
            if(!collider.gameObject.TryGetComponent(out Extinguishable fireExtinguishable))
                return;
            
            _extinguishable = null;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(!collider.gameObject.TryGetComponent(out Extinguishable fireExtinguishable))
                return;

            _extinguishable = fireExtinguishable;
            _extinguishable.Finished +=  _fireable.PutOut;
        }
    }
}