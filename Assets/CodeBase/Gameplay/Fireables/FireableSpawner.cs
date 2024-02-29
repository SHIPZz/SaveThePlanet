using System;
using System.Collections;
using CodeBase.Enums;
using CodeBase.Gameplay.TimerSystem;
using CodeBase.Gameplay.Tutorial;
using CodeBase.Services.Factories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Fireables
{
    public class FireableSpawner : MonoBehaviour, ITutoriable
    {
        public FireableType FireableType;
        public float StartSpawnDelay = 3f;
        public bool NeedSpawnOnStart;

        private GameFactory _gameFactory;
        private Fireable _fireable;
        private Timer _timer;

        public event Action Spawned;
        public event Action Completed;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
            _timer.Stopped += Spawn;
        }

        private void OnDisable()
        {
            if (_fireable != null)
                _fireable.OnPutOut -= RestartSpawnTime;

            _timer.Stopped -= Spawn;
        }

        [Button]
        public void Init()
        {
            Spawn();
        }

        private void RestartSpawnTime()
        {
            _timer.Stop();
            _timer.StartTimer();
            _fireable = null;
        }

        private void Spawn()
        {
            _fireable = _gameFactory.Create(FireableType, null, transform.position, transform.rotation);
            _fireable.OnPutOut += RestartSpawnTime;
            Spawned?.Invoke();
        }
    }
}