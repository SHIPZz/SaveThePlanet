using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Animations
{
    public class OnScalePointerAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _targetAnchoredScale;
        [SerializeField] private float _animationDuration = 0.2f;

        private Tween _tween;
        private Vector3 _initialScale;

        private void Awake()
        {
            _initialScale = _transform.localScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _tween?.Kill(true);
            _tween = _transform.DOScale(_targetAnchoredScale, _animationDuration).SetUpdate(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _tween?.Kill(true);
            _tween = _transform.DOScale(_initialScale, _animationDuration).SetUpdate(true);
        }
    }
}