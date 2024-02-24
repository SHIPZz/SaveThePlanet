using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        public float StopOffset;
        public float MovementDuration;
        public Vector3 CameraPanOffset;
        public Vector3 StartPosition;
        public Vector3 StartRotation;

        public bool IsMovingToTarget { get; private set; }

        public bool IsMoving { get; private set; }

        private Transform _target;
        private Tween _tween;

        public void MoveTo(Transform target, float movementBackDelay, Action onComplete = null,
            Action onTargetReached = null)
        {
            _target = target;
            _tween?.Kill();
            Vector3 targetPosition = target.position - target.forward * StopOffset;
            _tween = transform.DODynamicLookAt(_target.position, MovementDuration);
            IsMovingToTarget = true;
            IsMoving = true;

            _tween = transform
                .DOMove(targetPosition + CameraPanOffset, MovementDuration)
                .OnComplete(() =>
                {
                    onTargetReached?.Invoke();
                    _tween = DOTween.Sequence()
                        .AppendInterval(movementBackDelay)
                        .OnComplete(() => MoveAndRotateBack(onComplete));
                });
        }

        private void MoveAndRotateBack(Action onComplete)
        {
            IsMovingToTarget = false;
            _tween = transform.DOLocalRotate(StartRotation, MovementDuration);
            _tween = transform
                .DOLocalMove(StartPosition, MovementDuration)
                .OnComplete(() =>
                {
                    IsMoving = false;
                    onComplete?.Invoke();
                });
        }
    }
}