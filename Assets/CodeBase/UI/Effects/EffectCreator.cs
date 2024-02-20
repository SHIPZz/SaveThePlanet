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
        public Vector3 Offset;
        
        private UIFactory _uiFactory;
        private Effect _lastCreatedEffect;

        [Inject]
        private void Construct(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public Effect CreateAndPlay(Transform parent, Vector3 at)
        {
           Effect effect = _uiFactory.CreateAndPlay(EffectType, parent, at, Quaternion.Euler(Rotation));
           effect.transform.position += Offset;
           return effect;
        }

        public Effect CreateAndPlay(Transform parent, Vector3 at, bool setLocalPosition)
        {
            Effect effect = _uiFactory.CreateAndPlay(EffectType, parent, at, Quaternion.Euler(Rotation));

            effect.transform.localPosition = at;
            return effect;
        }
        
    }
}