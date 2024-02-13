using CodeBase.Enums;
using CodeBase.Services.StaticData;
using CodeBase.UI.Effects;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factories
{
    public class UIFactory
    {
        private readonly UIStaticDataService _uiStaticDataService;
        private readonly IInstantiator _instantiator;

        public UIFactory(UIStaticDataService uiStaticDataService, IInstantiator instantiator)
        {
            _uiStaticDataService = uiStaticDataService;
            _instantiator = instantiator;
        }

        public Effect Create(EffectType effectType, Transform parent, Vector3 at, Quaternion rotation)
        {
            Effect prefab = _uiStaticDataService.Get(effectType);
            
            return _instantiator.InstantiatePrefabForComponent<Effect>(prefab, at, rotation,parent);
        }
        
        public Effect CreateAndPlay(EffectType effectType, Transform parent, Vector3 at, Quaternion rotation)
        {
            Effect prefab = _uiStaticDataService.Get(effectType);
            
            var effect = _instantiator.InstantiatePrefabForComponent<Effect>(prefab, at, rotation,parent);
            effect.Particle.Play();
            return effect;
        }
    }
}