using CodeBase.Enums;
using CodeBase.Services.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Effects
{
    public class EffectCreator : MonoBehaviour
    {
        public Vector3 Rotation;
        public EffectType EffectType;
        private UIFactory _uiFactory;
        
        [Inject]
        private void Construct(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void CreateAndPlay(Transform parent, Vector3 at)
        {
            _uiFactory.CreateAndPlay(EffectType, parent, at, Quaternion.Euler(Rotation));
        }
    }
}