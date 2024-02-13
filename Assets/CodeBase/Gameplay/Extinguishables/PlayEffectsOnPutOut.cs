using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Extinguishables
{
    public class PlayEffectsOnPutOut : MonoBehaviour
    {
        public List<ParticleSystem> Effects;

        private Extinguishable _extinguishable;

        private void Awake()
        {
            _extinguishable = GetComponent<Extinguishable>();
        }

        private void OnEnable()
        {
            _extinguishable.PutOut += OnPutOut;
        }

        private void OnDisable()
        {
            _extinguishable.PutOut -= OnPutOut;
        }

        private void OnPutOut(Vector3 target, Vector3 rotation)
        {
            Effects.ForEach(x=>x.Play());
        }
    }
}