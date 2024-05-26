using System;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Gameplay.Throwables
{
    public class ChangeLayerOnCollisionAfterThrown : MonoBehaviour
    {
        [Layer] public int TargetLayer;
        [Layer] public int IgnoreLayer;

        private Throwable _throwable;
        private bool _isThrown;

        private void Awake() => 
            _throwable = GetComponent<Throwable>();

        private void OnEnable() => 
            _throwable.Thrown += SetIsThrown;

        private void OnDisable() => 
            _throwable.Thrown -= SetIsThrown;

        private void OnCollisionEnter(Collision other)
        {
            if(IgnoreLayer != 0 && other.gameObject.layer == IgnoreLayer)
                return;
            
            if (_isThrown)
                gameObject.layer = TargetLayer;
        }

        private void SetIsThrown()
        {
            _isThrown = true;
        }
    }
}