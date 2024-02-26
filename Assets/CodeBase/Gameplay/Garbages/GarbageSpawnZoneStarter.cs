using System;
using CodeBase.Enums;
using CodeBase.Gameplay.TimerSystem;
using CodeBase.Gameplay.Tutorial;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class GarbageSpawnZoneStarter : MonoBehaviour, ITutoriable
    {
        public GarbageSpawnZoneType GarbageSpawnZoneType;
        public bool SpawnOnStart;
        public float DelaySpawn = 3f;

        private GarbageSpawnZone _garbageSpawnZone;
        private Coroutine _spawnCoroutine;
        private Timer _timer;

        public event Action Completed;

        private void Awake()
        {
            _garbageSpawnZone = GetComponent<GarbageSpawnZone>();
            _timer = GetComponent<Timer>();
        }

        public void Init()
        {
            if (SpawnOnStart)
            {
                DOTween.Sequence().AppendInterval(DelaySpawn).OnComplete(_garbageSpawnZone.Spawn);
                return;
            }

            _timer.StartTimer();
        }

        private void OnEnable()
        {
            _timer.Stopped += _garbageSpawnZone.Spawn;
            _garbageSpawnZone.GarbagesDestroyed += OnGarbagesDestroyed;
        }

        private void OnDisable()
        {
            _timer.Stopped -= _garbageSpawnZone.Spawn;
            _garbageSpawnZone.GarbagesDestroyed -= OnGarbagesDestroyed;
        }

        private void OnGarbagesDestroyed()
        {
            _timer.StartTimer();
            Completed?.Invoke();
        }
    }
}