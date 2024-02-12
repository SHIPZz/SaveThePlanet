using System;
using CodeBase.Animations;
using CodeBase.Gameplay.MaterialChange;
using CodeBase.Gameplay.SoundPlayer;
using CodeBase.Services.TriggerObserve;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class CampFire : MonoBehaviour
    {
        public ParticleSystem Effect;
        public ParticleSystem SmokeEffect;
        public TriggerObserver PlayerTriggerObserver;
        public TransformScaleAnim ButtonScaleAnim;
        public SoundPlayerSystem SoundPlayerSystem;

        private bool _playerEntered;
        private bool _pressed;
        private MaterialChanger _materialChanger;

        private void Awake()
        {
            _materialChanger = GetComponent<MaterialChanger>();
        }

        private void OnEnable()
        {
            PlayerTriggerObserver.TriggerEntered += PlayerEntered;
            PlayerTriggerObserver.TriggerExited += PlayerExited;
            Effect.Play();
        }

        private void OnDisable()
        {
            PlayerTriggerObserver.TriggerEntered -= PlayerEntered;
            PlayerTriggerObserver.TriggerExited -= PlayerExited;
        }

        public void TryDisable()
        {
            if (_pressed || !_playerEntered)
                return;

            Effect.Stop();
            SmokeEffect.Play();
            _materialChanger.Change();
            SoundPlayerSystem.PlayInactiveSound();
            DOTween.Sequence().AppendInterval(1f)
                .OnComplete(() => transform.DOScale(0, 0.5f).OnComplete(() => Destroy(gameObject)));
        }

        private void PlayerExited(Collider obj)
        {
            _playerEntered = false;
            ButtonScaleAnim.UnScale();
        }

        private void PlayerEntered(Collider obj)
        {
            _playerEntered = true;
            ButtonScaleAnim.ToScale();
        }
    }
}