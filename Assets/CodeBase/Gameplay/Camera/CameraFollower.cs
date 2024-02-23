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

        private Transform _target;
        private Vector3 _lastPos;
        private Vector3 _lastRotation;

        public void MoveTo(Transform target, float movementBackDelay, Action onComplete = null, Action onTargetReached = null)
        {
            _target = target;
            Vector3 targetPosition = target.position - target.forward * StopOffset;
            _lastPos = transform.position;

            _lastRotation = transform.eulerAngles;
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
            _lastPos = transform.position;
            Vector3 targetPosition = target.position - target.forward * StopOffset;

            _lastRotation = transform.eulerAngles;
            
            transform.DODynamicLookAt(_target.position, MovementDuration);
            
            transform
                .DOMove(targetPosition + CameraPanOffset, MovementDuration)
                .OnComplete(() => MoveAndRotateBack(onComplete));
        }

        private void MoveAndRotateBack(Action onComplete)
        {
            transform.DORotate(_lastRotation, MovementDuration);
            transform
                .DOMove(_lastPos, MovementDuration)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}
