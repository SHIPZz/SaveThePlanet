using System;
using CodeBase.Gameplay.Tutorial;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class InitGarbageSpawnZoneStarterOnTutoriable : MonoBehaviour
    {
        private Tutoriable _tutoriable;
        private GarbageSpawnZoneStarter _garbageSpawnZoneStarter;

        private void Awake()
        {
            _tutoriable = GetComponent<Tutoriable>();
            _garbageSpawnZoneStarter = GetComponent<GarbageSpawnZoneStarter>();
        }

        private void OnEnable()
        {
            _tutoriable.UnLocked += _garbageSpawnZoneStarter.Init;
        }

        private void OnDisable()
        {
            _tutoriable.UnLocked -= _garbageSpawnZoneStarter.Init;
        }
    }
}