using System;
using CodeBase.Animations;
using CodeBase.UI.Effects;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.BucketWaters
{
    public class BucketWater : MonoBehaviour
    {
        public EffectPlayer EffectPlayer;
        public float RotationTime = 0.5f;
        public float MovementTime = 0.5f;
        public Vector3 Offset = new Vector3(0, 2f,0);
        public float PourTime = 3f;

        public Transform Transform => transform;
        public Transform Anchor => transform;

        private TransformScaleAnim _transformScaleAnim;

        private void Awake() => 
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
    }
}