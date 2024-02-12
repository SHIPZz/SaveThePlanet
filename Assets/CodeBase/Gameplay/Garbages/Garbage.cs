using System;
using CodeBase.Animations;
using CodeBase.Constant;
using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class Garbage : MonoBehaviour, ITakeable, IThrowable
    {
        public float MovementDuration = 0.5f;
        public float RotationSpeed = 5;
        public GarbageType GarbageType;
        
        public Transform Transform => transform;

        private readonly GarbageMovement _garbageMovement = new();
        private TransformScaleAnim _transformScaleAnim;
        private bool _canRotate;
        private Rigidbody _rigidBody;

        public event Action<ITakeable> Dropped;

        private void Awake()
        {
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void Update()
        {
            if (_canRotate)
                _garbageMovement.Rotate(_rigidBody, RotationSpeed);
        }

        public void SetRotation()
        {
            _canRotate = true;
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer != LayerId.Player && gameObject.layer != LayerId.Garbage)
                gameObject.layer = LayerId.Garbage;

            _canRotate = false;
            
            if (!other.gameObject.TryGetComponent(out Bin bin))
                return;

            var rb = gameObject.GetComponent<Rigidbody>();

            if (bin.GarbageType != GarbageType)
            {
                if (rb != null)
                    _garbageMovement.Jump(bin.transform.forward, rb, 10f);

                return;
            }
            
            if (rb != null)
                Destroy(rb);

            transform.SetParent(bin.GarbagePosition);

            _garbageMovement.Move(MovementDuration, Vector3.zero, this);
            _transformScaleAnim.UnScale();
        }
    }
}