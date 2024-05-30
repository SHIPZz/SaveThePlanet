using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace CodeBase.Animations
{
    public class TransformScaleAnim : MonoBehaviour
    {
        [SerializeField] private float _targetScale = 1f;
        [SerializeField] private float _unScale;
        [SerializeField] private float _scaleDuration = 0.2f;
        [SerializeField] private float _unScaleDuration = 0.1f;
        [SerializeField] private Transform _transform;
        [SerializeField] private bool _scaleX;
        [SerializeField] private bool _scaleY;
        [SerializeField] private bool _scaleZ;
        [SerializeField] private bool _unscaleOnStart;
        [SerializeField] private float _scaleDelay = 1f;
        [SerializeField] private bool _getTransformOnAwake;

        private Tween _tween;

        private void Awake()
        {
            if (_getTransformOnAwake)
                _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            if (_unscaleOnStart)
                UnScale();
        }

        public void ToScale(float delay, Action onComplete = null)
        {
            DOTween.Sequence().AppendInterval(delay).OnComplete(() => ToScale(onComplete)).SetUpdate(true);
        }

        public void ToScale([CanBeNull] Action onComplete = null)
        {
            _transform.gameObject.SetActive(true);
            SetTween(Vector3.one * _targetScale, _scaleDuration, onComplete);
        }

        public void ToDefaultScale(Action onComplete = null)
        {
            SetTween(Vector3.one, _scaleDuration, onComplete);
        }

        public void UnScaleQuickly(Action onComplete = null)
        {
            SetTween(Vector3.one * _unScale, 0.1f, onComplete);
        }

        public async UniTaskVoid ToScaleAsync(Action onComplete = null)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_scaleDelay),true);

            SetTween(Vector3.one * _targetScale, _scaleDuration, onComplete);
        }

        public void UnScaleAndScale(Action onComplete = null)
        {
            UnScale(() => ToScale());
        }

        public void UnScale(Action onComplete = null)
        {
            SetTween(Vector3.one * _unScale, _unScaleDuration, onComplete);
        }

        private void SetTween(Vector3 scale, float duration, Action onComplete = null)
        {
            _tween?.SetUpdate(true).Kill(true);

            switch (true)
            {
                case bool _ when _scaleX:
                    _tween = _transform.DOScaleX(scale.x, duration).OnComplete(() => onComplete?.Invoke())
                        .SetUpdate(true);
                    break;
                case bool _ when _scaleY:
                    _tween = _transform.DOScaleY(scale.y, duration).OnComplete(() => onComplete?.Invoke())
                        .SetUpdate(true);
                    break;
                case bool _ when _scaleZ:
                    _tween = _transform.DOScaleZ(scale.z, duration).OnComplete(() => onComplete?.Invoke())
                        .SetUpdate(true);
                    break;
                default:
                    _tween = _transform.DOScale(scale, duration).OnComplete(() => onComplete?.Invoke()).SetUpdate(true);
                    break;
            }
        }
    }
}