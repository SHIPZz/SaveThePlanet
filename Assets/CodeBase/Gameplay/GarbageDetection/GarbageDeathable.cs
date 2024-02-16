using System;
using CodeBase.Extensions;
using CodeBase.Services.GarbageDeathableServices;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.GarbageDetection
{
    public class GarbageDeathable : MonoBehaviour
    {
        [field: SerializeField] public string Id { get; private set; }

        [field: SerializeField] public bool IsDead { get; private set; }

        private DieEventOnGarbageDetected _dieEventOnGarbageDetected;
        private GarbageDeathableService _garbageDeathableService;

        [Inject]
        private void Construct(GarbageDeathableService garbageDeathableService) =>
            _garbageDeathableService = garbageDeathableService;

        private void Awake() =>
            _dieEventOnGarbageDetected = GetComponent<DieEventOnGarbageDetected>();

        private void OnEnable() =>
            _dieEventOnGarbageDetected.Dead += SetIsDead;

        private void OnDisable() =>
            _dieEventOnGarbageDetected.Dead -= SetIsDead;

        private void SetIsDead()
        {
            IsDead = true;
            _garbageDeathableService.SetToData(this.ToData());
        }

        [Button]
        private void CreateId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}