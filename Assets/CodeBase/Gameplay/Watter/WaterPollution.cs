using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Watter
{
    public class WaterPollution : MonoBehaviour
    {
        private const string Property = "_WaterDeepColor";

        public Renderer Renderer;
        public float Duration = 1.5f;
        public Color TargetColor;
        public Color ClearColor;

        private void OnDisable()
        {
            Renderer.sharedMaterial.DOColor(ClearColor, Property, 0f);
        }

        [Button]
        public void Pollute()
        {
            Renderer.sharedMaterial
                .DOColor(TargetColor, Property, Duration);
        }

        [Button]
        public void Clear()
        {
            Renderer.sharedMaterial.DOColor(ClearColor, Property, Duration);
        }
    }
}