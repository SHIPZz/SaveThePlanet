using System;
using System.Collections.Generic;
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
    public class UIFactory : ITickable, IDisposable, IInitializable
    {
        private readonly UIStaticDataService _uiStaticDataService;
        private readonly IInstantiator _instantiator;
        private readonly LocationProvider _locationProvider;
        
        private List<ITickable> _tickables = new();
        private List<IDisposable> _disposables = new();
        private List<IInitializable> _initializables = new();

        public UIFactory(UIStaticDataService uiStaticDataService, IInstantiator instantiator,
            LocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
            _uiStaticDataService = uiStaticDataService;
            _instantiator = instantiator;
        }
        
        public void Tick()
        {
            foreach (ITickable tickable in _tickables)
            {
                tickable.Tick();
            }
        }

        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }
        }

        public void Initialize()
        {
        }

        public T CreateWindowController<T>() where T : IWindowController
        {
            var windowController = _instantiator.Instantiate<T>();
            
            if(windowController is IInitializable initializable)
                initializable.Initialize();
            
            if(windowController is ITickable tickable)
                AddToTickables(tickable);
            
            if(windowController is IDisposable disposable)
                AddToDisposables(disposable);

            return windowController;
        }

        public AbstractTutorialStep CreateTutorialStepView(TutorialType tutorialType, Transform parent, Vector3 at,
            Quaternion rotation, TutorialRunner tutorialRunner)
        {
            AbstractTutorialStep prefab = _uiStaticDataService.GetTutorialStep(tutorialType);

            var createdStep = _instantiator.InstantiatePrefabForComponent<AbstractTutorialStep>(prefab, at, rotation, parent);
            createdStep.transform.localPosition = at;
            createdStep.transform.localScale = Vector3.one;
            createdStep.Init(tutorialRunner);
            createdStep.AddToData();
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
        
        private void AddToTickables(ITickable tickable) =>
            _tickables.Add(tickable);

        private void AddToDisposables(IDisposable disposable) =>
            _disposables.Add(disposable);

        private void AddToInitializables(IInitializable initializable) =>
            _initializables.Add(initializable);
    }
}