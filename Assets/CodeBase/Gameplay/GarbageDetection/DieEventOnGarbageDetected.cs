using System;
using UnityEngine;

namespace CodeBase.Gameplay.GarbageDetection
{
    public class DieEventOnGarbageDetected : MonoBehaviour
    {
        private GarbageDetector _garbageDetector;

        public event Action Dead;

        private void Awake()
        {
            _garbageDetector = GetComponent<GarbageDetector>();
        }

        private void OnEnable()
        {
            _garbageDetector.Detected += Die;
        }

        private void OnDisable()
        {
            _garbageDetector.Detected -= Die;
        }

        private void Die(GarbageDetector garbageDetector)
        {
            _garbageDetector.enabled = false;
            Dead?.Invoke();
        }
    }
}