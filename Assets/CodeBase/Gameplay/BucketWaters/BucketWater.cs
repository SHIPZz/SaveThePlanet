using System;
using CodeBase.Animations;
using CodeBase.UI.Effects;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.BucketWaters
{
    public class BucketWater : MonoBehaviour, ITakeable, IFireExtinguishable
    {
        public EffectPlayer EffectPlayer;
        public float RotationTime = 0.5f;
        public float MovementTime = 0.5f;
        public Vector3 Offset = new Vector3(0, 2f,0);
        public float PourTime = 3f;

        public Transform Transform => transform;
        public Transform Anchor => transform;

        public event Action<ITakeable> Dropped;
        public event Action<IFireExtinguishable> Done;

        private TransformScaleAnim _transformScaleAnim;

        private void Awake() => 
            _transformScaleAnim = GetComponent<TransformScaleAnim>();

        public void MoveTo(Vector3 target, Action onComplete = null) =>
            transform.DOLocalJump(target + Offset, 1, 1, MovementTime)
                .OnComplete(() => onComplete?.Invoke());

        public void RotateTo(Vector3 target, Action onComplete = null) => 
            transform.up = target;

        public void PutOut()
        {
            EffectPlayer.PlayEffects();
            
            DOTween.Sequence().AppendInterval(PourTime).OnComplete(() =>
            {
                EffectPlayer.StopEffects();
                _transformScaleAnim.UnScale(() =>
                {
                    Done?.Invoke(this);
                    Dropped?.Invoke(this);
                });
            });
        }
    }
}