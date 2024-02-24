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
        
        private static readonly int _waterDeepColor = Shader.PropertyToID(Property);

        private void OnDisable()
        {
            Renderer.sharedMaterial.SetColor(_waterDeepColor, ClearColor);
        }

        [Button]
        public void Pollute()
        {
            Renderer.sharedMaterial
                .DOColor(TargetColor, _waterDeepColor, Duration);
        }

        [Button]
        public void Clear()
        {
            Renderer.sharedMaterial.DOColor(ClearColor, _waterDeepColor, Duration);
        }
    }
}