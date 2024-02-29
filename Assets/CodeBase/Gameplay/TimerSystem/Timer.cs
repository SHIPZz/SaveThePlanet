using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Gameplay.TimerSystem
{
    public class Timer : MonoBehaviour
    {
        [field: SerializeField] public float Value { get; private set; } = 300f;

        private Coroutine _coroutine;
        private float _initialTimer;

        public event Action Started;
        public event Action Stopped;

        private void Awake()
        {
            _initialTimer = Value;
        }

        public void StartTimer()
        {
            Started?.Invoke();

            ResetValue();

            if (_coroutine != null)
                StopCoroutine(UpdateTimeCoroutine());

            _coroutine = StartCoroutine(UpdateTimeCoroutine());
        }

        public void Stop()
        {
            ResetValue();
            Stopped?.Invoke();

            if (_coroutine != null)
                StopCoroutine(UpdateTimeCoroutine());
        }

        private IEnumerator UpdateTimeCoroutine()
        {
            while (Value > 0)
            {
                Value -= Time.deltaTime;
                yield return null;
            }

            ResetValue();
            Stopped?.Invoke();
        }

        private void ResetValue()
        {
            Value = _initialTimer;
        }
    }
}