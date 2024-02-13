using System;
using CodeBase.Animations;
using CodeBase.Gameplay.MaterialChange;
using CodeBase.Gameplay.SoundPlayer;
using CodeBase.Services.TriggerObserve;
using CodeBase.UI.Effects;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class CampFire : MonoBehaviour, IFireable
    {
        public ParticleSystem Effect;
        public TriggerObserver PlayerTriggerObserver;
        public TransformScaleAnim ButtonScaleAnim;
        public SoundPlayerSystem SoundPlayerSystem;
        public EffectPlayer EffectPlayer;
        public float DestroyDelay = 3f;

        private MaterialChanger _materialChanger;

        public Transform Anchor => transform;

        private void Awake() => 
            _materialChanger = GetComponent<MaterialChanger>();

        private void OnEnable() => 
            Effect.Play();

        public void Disable()
        {
            Effect.Stop();
            EffectPlayer.PlayEffects();
            _materialChanger.Change();
            ButtonScaleAnim.UnScaleQuickly();
            SoundPlayerSystem.PlayInactiveSound();
            DOTween.Sequence().AppendInterval(DestroyDelay)
                .OnComplete(() => transform.DOScale(0, 0.5f).OnComplete(() => Destroy(gameObject)));
        }

        private void PlayerExited(Collider obj)
        {
            ButtonScaleAnim.UnScale();
        }

        private void PlayerEntered(Collider obj)
        {
            // ButtonScaleAnim.ToScale();
        }
    }
}