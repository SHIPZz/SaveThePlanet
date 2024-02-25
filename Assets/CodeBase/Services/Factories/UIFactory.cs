using CodeBase.Enums;
using CodeBase.Gameplay.Tutorial;
using CodeBase.Services.Providers.LocationProviders;
using CodeBase.Services.StaticData;
using CodeBase.UI.Effects;
using CodeBase.UI.Windows;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factories
{
    public class UIFactory
    {
        private readonly UIStaticDataService _uiStaticDataService;
        private readonly IInstantiator _instantiator;
        private readonly LocationProvider _locationProvider;

        public UIFactory(UIStaticDataService uiStaticDataService, IInstantiator instantiator,
            LocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
            _uiStaticDataService = uiStaticDataService;
            _instantiator = instantiator;
        }

        public T CreateTutorialStep<T>(Transform parent, Vector3 at, Quaternion rotation) where T : TutorialStep
        {
            var prefab = _uiStaticDataService.GetTutorialStep<T>();
            
            var createdStep = _instantiator.InstantiatePrefabForComponent<T>(prefab, at, rotation, parent);
            createdStep.transform.localPosition = at;
            createdStep.transform.localScale = Vector3.one;
            return createdStep;
        }

        public Effect Create(EffectType effectType, Transform parent, Vector3 at, Quaternion rotation)
        {
            Effect prefab = _uiStaticDataService.Get(effectType);

            return _instantiator.InstantiatePrefabForComponent<Effect>(prefab, at, rotation, parent);
        }

        public Effect CreateAndPlay(EffectType effectType, Transform parent)
        {
            Effect prefab = _uiStaticDataService.Get(effectType);

            var effect = _instantiator.InstantiatePrefabForComponent<Effect>(prefab, parent);
            effect.Particle.Play();
            return effect;
        }

        public Effect CreateAndPlay(EffectType effectType, Transform parent, Vector3 at, Quaternion rotation)
        {
            Effect prefab = _uiStaticDataService.Get(effectType);

            var effect = _instantiator.InstantiatePrefabForComponent<Effect>(prefab, at, rotation, parent);
            effect.Particle.Play();
            return effect;
        }

        public T CreateWindow<T>() where T : WindowBase
        {
            var prefab = _uiStaticDataService.Get<T>();

            return _instantiator.InstantiatePrefabForComponent<T>(prefab, _locationProvider.UIParent);
        }
    }
}