using UnityEngine;

namespace CodeBase.Gameplay.MaterialChange
{
    public class MaterialChanger : MonoBehaviour
    {
        public MeshRenderer MeshRenderer;

        public Material TargetMaterial;

        public void Change()
        {
            MeshRenderer.material = TargetMaterial;
        }
    }
}