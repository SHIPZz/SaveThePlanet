using System;
using CodeBase.Gameplay.GarbageDetection;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    [RequireComponent(typeof(GarbageDetector))]
    [RequireComponent(typeof(DestroyableObject))]
    public class DestroyOnGarbageDetected : MonoBehaviour
    {
        private GarbageDetector _garbageDetector;
        private DestroyableObject _destroyableObject;

        private void Awake()
        {
            _garbageDetector = GetComponent<GarbageDetector>();
            _destroyableObject = GetComponent<DestroyableObject>();
        }

        private void OnEnable()
        {
            _garbageDetector.Detected += _destroyableObject.DoDestroy;
        }

        private void OnDisable()
        {
            _garbageDetector.Detected -= _destroyableObject.DoDestroy;
        }
    }
}