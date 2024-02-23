using System;
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

        private Transform _target;

        public void MoveTo(Transform target, float movementBackDelay, Action onComplete = null, Action onTargetReached = null)
        {
            _target = target;
            Vector3 targetPosition = target.position - target.forward * StopOffset;
            transform.DODynamicLookAt(_target.position, MovementDuration);
            
            transform
                .DOMove(targetPosition + CameraPanOffset, MovementDuration)
                .OnComplete(() =>
                {
                    onTargetReached?.Invoke();
                    DOTween.Sequence()
                        .AppendInterval(movementBackDelay)
                        .OnComplete(() => MoveAndRotateBack(onComplete));
                });
        }

        public void MoveTo(Transform target, Action onComplete = null)
        {
            _target = target;
            Vector3 targetPosition = target.position - target.forward * StopOffset;

            transform.DODynamicLookAt(_target.position, MovementDuration);
            
            transform
                .DOMove(targetPosition + CameraPanOffset, MovementDuration)
                .OnComplete(() => MoveAndRotateBack(onComplete));
        }

        private void MoveAndRotateBack(Action onComplete)
        {
            transform.DOLocalRotate(StartRotation, MovementDuration);
            transform
                .DOLocalMove(StartPosition, MovementDuration)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}
