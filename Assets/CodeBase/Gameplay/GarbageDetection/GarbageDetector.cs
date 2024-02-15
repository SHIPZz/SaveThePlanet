using System;
using CodeBase.Gameplay.Garbages;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.GarbageDetection
{
    public class GarbageDetector : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        public event Action<GarbageDetector> Detected;

        private void OnEnable()
        {
            TriggerObserver.TriggerEntered += OnDetected;
        }

        private void OnDisable()
        {
            TriggerObserver.TriggerEntered -= OnDetected;
        }

        private void OnDetected(Collider collider)
        {
            if (!collider.gameObject.TryGetComponent(out Garbage garbage))
                return;

            Detected?.Invoke(this);
        }
    }
}