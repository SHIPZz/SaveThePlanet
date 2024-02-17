using System.Collections.Generic;
using System.Linq;
using AmazingAssets.AdvancedDissolve;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Gameplay.Burnables
{
    public class ChangeMaterialOnBurnable : MonoBehaviour
    {
        public Material TargetMaterial;
        public float Duration = 1.5f;
        public Renderer Renderer;
        public List<Material> StartMaterials;

        private Burnable _burnable;
        private Material[] _initialMaterials;
        private bool _changed;
        
        private void Awake()
        {
            _burnable = GetComponent<Burnable>();
            StartMaterials = Renderer.sharedMaterials.ToList();
        }

        private void OnEnable()
        {
            _burnable.Burned += ChangeMaterial;
            _burnable.Recovered += SetInitialMaterials;
        }

        private void OnDisable()
        {
            _burnable.Burned -= ChangeMaterial;
            _burnable.Recovered -= SetInitialMaterials;
        }

        private void SetInitialMaterials(Burnable obj)
        {
            DOTween.To(() => 1f, SetMaterialValue, 0f, Duration)
                .OnComplete(() =>
                {
                    Renderer.materials = StartMaterials.ToArray();
                    _changed = false;
                });
        }

        private void ChangeMaterial(Burnable obj)
        {
            if(_changed)
                return;
            
            
            _changed = true;
            Material[] newMaterials = new Material[Renderer.materials.Length];

            float startValue = 0f;
            float endValue = 1f;

            for (int i = 0; i < newMaterials.Length; i++)
                newMaterials[i] = TargetMaterial;

            Renderer.materials = newMaterials;

            DOTween.To(() => 0, SetMaterialValue, endValue, Duration);
        }

        private void SetMaterialValue(float x)
        {
            foreach (Material material in Renderer.materials)
            {
                material.SetFloat(AdvancedDissolveProperties.Cutout.Standard.ids[0].clip, x);
            }
        }
    }
}