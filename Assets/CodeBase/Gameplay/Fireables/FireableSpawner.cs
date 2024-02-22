using System;
using System.Collections;
using CodeBase.Enums;
using CodeBase.Gameplay.TimerSystem;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Fireables
{
    public class FireableSpawner : MonoBehaviour
    {
        public FireableType FireableType;
        public float StartSpawnDelay = 3f;
        public bool NeedSpawnOnStart;

        private GameFactory _gameFactory;
        private Fireable _fireable;
        private Timer _timer;

        public event Action Spawned;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }

        private IEnumerator Start()
        {
            if (!NeedSpawnOnStart)
            {
                _timer.StartTimer();
                yield break;
            }

            yield return new WaitForSeconds(StartSpawnDelay);
            Spawn();
        }

        private void OnEnable()
        {
            _timer.Stopped += Spawn;
        }
        
        private void OnDisable()
        {
            if (_fireable != null)
                _fireable.OnPutOut -= OnPutOut;

            _timer.Stopped -= Spawn;
        }

        private void OnPutOut()
        {
            _timer.Stop();
            _timer.StartTimer();
            _fireable = null;
        }

        private void Spawn()
        {
            _fireable = _gameFactory.Create(FireableType, null, transform.position, transform.rotation);
            _fireable.OnPutOut += OnPutOut;
            Spawned?.Invoke();
        }
    }
}