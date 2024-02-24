using CodeBase.Gameplay.MaterialChange;
using UnityEngine;

namespace CodeBase.Gameplay.Burnables
{
    public class ChangeMaterialOnBurnable : MonoBehaviour
    {
        private Burnable _burnable;
        private bool _changed;
        private MaterialChanger _materialChanger;

        private void Awake()
        {
            _burnable = GetComponent<Burnable>();
            _materialChanger = GetComponent<MaterialChanger>();
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
            _materialChanger.SetInitialMaterials();
        }

        private void ChangeMaterial(Burnable obj)
        {
            _materialChanger.ChangeMaterial();
        }
    }
}