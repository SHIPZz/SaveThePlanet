using System;
using CodeBase.Gameplay.GarbageDetection;
using Polyperfect.Animals;
using UnityEngine;

namespace CodeBase.Gameplay.Animals
{
    public class AnimalDieOnGarbageDetectedEvent : MonoBehaviour
    {
        private Animal_WanderScript _animalWanderScript;
        private DieEventOnGarbageDetected _dieEventOnGarbageDetected;

        private void Awake()
        {
            _animalWanderScript = GetComponent<Animal_WanderScript>();
            _dieEventOnGarbageDetected = GetComponent<DieEventOnGarbageDetected>();
        }

        private void OnEnable()
        {
            _dieEventOnGarbageDetected.Dead += Die;
        }

        private void OnDisable()
        {
            _dieEventOnGarbageDetected.Dead -= Die;
        }

        private void Die()
        {
            _animalWanderScript.Die();
        }
    }
}