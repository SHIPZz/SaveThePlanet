using System;
using CodeBase.Animations;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class AutoAnimationDestroyObjectPart : MonoBehaviour
    {
        public float Delay;

        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable()
        {
            DOTween.Sequence().AppendInterval(Delay)
                .OnComplete(() => _transformScaleAnim.UnScale(() => Destroy(gameObject)));
        }
    }
}