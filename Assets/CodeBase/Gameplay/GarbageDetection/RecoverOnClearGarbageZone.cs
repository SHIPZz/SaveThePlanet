using System;
using CodeBase.Gameplay.Garbages;
using CodeBase.Services.GarbageDeathableServices;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.GarbageDetection
{
    [RequireComponent(typeof(GarbageSpawnZoneDetector))]
    public class RecoverOnClearGarbageZone : MonoBehaviour
    {
        public GarbageDeathable GarbageDeathable;
        public DieEventOnGarbageDetected DieOnGarbageDetected;

        private GarbageDeathable _garbageDeathable;
        private GarbageSpawnZoneDetector _garbageSpawnZoneDetector;
        private GarbageSpawnZone _garbageSpawnZone;
        private GarbageDeathableService _garbageDeathableService;
        private string _id;
        private bool _isDead;

        public event Action<GarbageDeathable> Recovered; 

        [Inject]
        private void Construct(GarbageDeathableService garbageDeathableService) => 
            _garbageDeathableService = garbageDeathableService;

        private void Awake()
        {
            _garbageSpawnZoneDetector = GetComponent<GarbageSpawnZoneDetector>();
            _id = GarbageDeathable.Id;
        }

        private void OnEnable()
        {
            _garbageSpawnZoneDetector.Detected += OnGarbageDetected;
            DieOnGarbageDetected.Dead += OnDead;
        }

        private void OnDisable()
        {
            _garbageSpawnZoneDetector.Detected -= OnGarbageDetected;
            DieOnGarbageDetected.Dead -= OnDead;
        }

        private void OnGarbageDetected(GarbageSpawnZone garbageSpawnZone)
        {
            _garbageSpawnZoneDetector.enabled = false;
            _garbageSpawnZone = garbageSpawnZone;
            _garbageSpawnZone.GarbagesDestroyed += Recover;
        }

        private void OnDead()
        {
            _isDead = true;
            transform.SetParent(null);
        }

        private void Recover()
        {
            if(!_isDead)
                return;
            
            GarbageDeathable garbageDeathable = _garbageDeathableService.RecoverByCreate(_id);
            _garbageSpawnZone.GarbagesDestroyed -= Recover;
            Recovered?.Invoke(garbageDeathable);
            Destroy(gameObject);
        }
    }
}