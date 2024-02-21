using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Extinguishables
{
    public class SetMovementOnPutOut : MonoBehaviour
    {
        public float RotationTime = 0.5f;
        public float MovementTime = 0.5f;
        public Vector3 Offset = new Vector3(0, 2f,0);
        
        private Extinguishable _extinguishable;

        private void Awake() => 
            _extinguishable = GetComponent<Extinguishable>();

        private void OnEnable() => 
            _extinguishable.PutOut += OnPutOut;

        private void OnDisable() => 
            _extinguishable.PutOut -= OnPutOut;

        private void OnPutOut(Vector3 target, Vector3 rotation)
        {
            transform.DOLocalJump(target + Offset, 1, 1, MovementTime);
            transform.up = rotation;
        }
    }
}