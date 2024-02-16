using System;
using CodeBase.Gameplay.Garbages;
using CodeBase.Services.TriggerObserves;
using UnityEngine;

namespace CodeBase.Gameplay.GarbageDetection
{
    public class GarbageSpawnZoneDetector : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        public event Action<GarbageSpawnZone> Detected;

        private void OnEnable()
        {
            TriggerObserver.TriggerEntered += OnGarbageSpawnZoneDetected;
        }

        private void OnDisable()
        {
            TriggerObserver.TriggerEntered -= OnGarbageSpawnZoneDetected;
        }

        private void OnGarbageSpawnZoneDetected(Collider collider)
        {
            var garbageSpawnZone = collider.gameObject.GetComponent<GarbageSpawnZone>();
            Detected?.Invoke(garbageSpawnZone);
        }
    }
}