using System;
using CodeBase.Animations;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    [RequireComponent(typeof(TransformScaleAnim))]
    public class AutoAnimationDestroyObjectPart : MonoBehaviour
    {
        public float Delay = 3f;

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