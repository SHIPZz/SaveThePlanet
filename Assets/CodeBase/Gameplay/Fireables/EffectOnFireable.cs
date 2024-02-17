using System;
using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    [RequireComponent(typeof(Fireable))]
    [RequireComponent(typeof(EffectPlayer))]
    public class EffectOnFireable : MonoBehaviour
    {
        public bool PlayOnEnable;
        public ParticleSystem FireEffect;

        private Fireable _fireable;
        private EffectPlayer _putOutEffectPlayer;

        private void Awake()
        {
            _fireable = GetComponent<Fireable>();
            _putOutEffectPlayer = GetComponent<EffectPlayer>();
        }

        private void OnEnable()
        {
            if(PlayOnEnable)
                PlayFireEffect();
            
            _fireable.OnFired += PlayFireEffect;
            _fireable.OnPutOut += PlayPutOutEffects;
        }

        private void OnDisable()
        {
            _fireable.OnFired -= PlayFireEffect;
            _fireable.OnPutOut -= PlayPutOutEffects;
        }

        private void PlayPutOutEffects()
        {
            FireEffect.Stop();
            _putOutEffectPlayer.PlayEffects();
        }

        private void PlayFireEffect()
        {
            FireEffect.Play();
        }
    }
}