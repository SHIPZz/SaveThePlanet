using CodeBase.Anims;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    [RequireComponent(typeof(Fireable))]
    public class IncreaseColliderRadiusOnFireable : MonoBehaviour
    {
        public bool IncreaseOnEnable;
        public float StartRadius = 1f;
        public float TargetRadius = 6f;
        public float Duration = 10f;
        public SphereCollider SphereCollider;

        private Fireable _fireable;
        private Tween _tween;

        private void Awake()
        {
            _fireable = GetComponent<Fireable>();
        }

        private void OnEnable()
        {
            if (IncreaseOnEnable)
                Increase();

            SphereCollider.radius = StartRadius;
            _fireable.OnFired += Increase;
            _fireable.OnPutOut += StopIncreasing;
        }

        private void OnDisable()
        {
            _fireable.OnFired -= Increase;
            _fireable.OnPutOut -= StopIncreasing;
        }

        [Button]
        private void StopIncreasing()
        {
            _tween?.Kill();
        }

        private void Increase()
        {
            _tween = DOTween.To(() => SphereCollider.radius, value => SphereCollider.radius = value, TargetRadius,
                Duration);
        }
    }
}