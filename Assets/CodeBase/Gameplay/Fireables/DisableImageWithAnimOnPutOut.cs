using System;
using CodeBase.Anims;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Gameplay.Fireables
{
    public class DisableImageWithAnimOnPutOut : MonoBehaviour
    {
        public TransformScaleAnim TransformScaleAnim;

        private Fireable _fireable;

        private void Awake() => 
            _fireable = GetComponent<Fireable>();

        private void OnEnable() => 
            _fireable.OnPutOut += Disable;

        private void OnDisable() => 
            _fireable.OnPutOut -= Disable;

        private void Disable() => 
            TransformScaleAnim.UnScale();
    }
}