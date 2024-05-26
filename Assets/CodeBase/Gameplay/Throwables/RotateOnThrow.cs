using UnityEngine;

namespace CodeBase.Gameplay.Throwables
{
    public class RotateOnThrow : MonoBehaviour
    {
        public float RotationSpeed = 8f;

        private Throwable _throwable;
        private bool _canRotate;
        private Rigidbody _rigidBody;

        private void Awake() => 
            _throwable = GetComponent<Throwable>();

        private void OnEnable() => 
            _throwable.Thrown += SetCanRotate;

        private void OnDisable() => 
            _throwable.Thrown -= SetCanRotate;

        private void Update()
        {
            if (!_canRotate)
                return;

            if (_rigidBody != null)
                _rigidBody.AddTorque(_rigidBody.transform.right * RotationSpeed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            _canRotate = false;
            _rigidBody = null;
        }

        private void SetCanRotate()
        {
            _canRotate = true;
            _rigidBody = GetComponent<Rigidbody>();
        }
    }
}