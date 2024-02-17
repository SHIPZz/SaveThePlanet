using CodeBase.Gameplay.MaterialChange;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    public class ChangeMaterialOnPutOut : MonoBehaviour
    {
        private Fireable _fireable;
        private MaterialChanger _materialChanger;

        private void Awake()
        {
            _fireable = GetComponent<Fireable>();
            _materialChanger = GetComponent<MaterialChanger>();
        }

        private void OnEnable() => 
            _fireable.OnPutOut += ChangeMaterial;

        private void OnDisable() => 
            _fireable.OnPutOut -= ChangeMaterial;

        private void ChangeMaterial()
        {
            _materialChanger.Change();
        }
    }
}