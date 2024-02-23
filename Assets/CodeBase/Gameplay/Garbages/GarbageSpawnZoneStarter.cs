using CodeBase.Gameplay.TimerSystem;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class GarbageSpawnZoneStarter : MonoBehaviour
    {
        public bool SpawnOnStart;
        public float DelaySpawn = 3f;

        private GarbageSpawnZone _garbageSpawnZone;
        private Coroutine _spawnCoroutine;
        private Timer _timer;

        private void Awake()
        {
            _garbageSpawnZone = GetComponent<GarbageSpawnZone>();
            _timer = GetComponent<Timer>();
        }

        private void Start()
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
            _garbageSpawnZone.GarbagesDestroyed += _timer.StartTimer;
        }

        private void OnDisable()
        {
            _timer.Stopped -= _garbageSpawnZone.Spawn;
            _garbageSpawnZone.GarbagesDestroyed -= _timer.StartTimer;
        }
    }
}