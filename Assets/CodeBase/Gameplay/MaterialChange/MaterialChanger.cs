using System.Collections.Generic;
using System.Linq;
using AmazingAssets.AdvancedDissolve;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.MaterialChange
{
    public class MaterialChanger : MonoBehaviour
    {
        public float Duration = 1.5f;
        public Material TargetMaterial;
        public bool GetRendererInChildren = true;

        private bool _changed;
        private List<Material> _startMaterials;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetRendererInChildren ? GetComponentInChildren<Renderer>() : GetComponent<Renderer>();

            _startMaterials = _renderer.sharedMaterials.ToList();
        }

        public void SetInitialMaterials()
        {
            DOTween.To(() => 1f, SetMaterialValue, 0f, Duration)
                .OnComplete(() =>
                {
                    _renderer.materials = _startMaterials.ToArray();
                    _changed = false;
                });
        }

        public void ChangeMaterial()
        {
            if (_changed)
                return;

            _changed = true;
            Material[] newMaterials = new Material[_renderer.materials.Length];

            float startValue = 0f;
            float endValue = 1f;

            for (int i = 0; i < newMaterials.Length; i++)
                newMaterials[i] = TargetMaterial;

            _renderer.materials = newMaterials;

            DOTween.To(() => 0, SetMaterialValue, endValue, Duration);
        }

        private void SetMaterialValue(float x)
        {
            foreach (Material material in _renderer.materials)
            {
                material.SetFloat(AdvancedDissolveProperties.Cutout.Standard.ids[0].clip, x);
            }
        }
    }
}