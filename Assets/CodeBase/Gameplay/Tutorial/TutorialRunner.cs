using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using CodeBase.UI.Windows.Tutorial;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialRunner : IDisposable
    {
        private Dictionary<TutorialType, TutorialStep> _tutorialSteps = new();
        private TutorialStep _lastStep;
        private UIFactory _uiFactory;

        public TutorialContainer TutorialContainer { get; private set; }

        public event Action<TutorialType> StepSwitched;

        public TutorialRunner(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Dispose()
        {
            foreach (TutorialStep tutorialStep in _tutorialSteps.Values)
            {
                IDisposable disposable = tutorialStep as IDisposable;
                disposable?.Dispose();
            }
        }

        public void Init(TutorialContainer tutorialContainer)
        {
            TutorialContainer = tutorialContainer;
        }

        public void SetStep<T>() where T : TutorialStep
        {
            _lastStep?.OnFinished();
            _lastStep = CreateStep<T>();
            _lastStep.OnStart();
        }

        public void TrySwitchToNextStep(TutorialType tutorialType)
        {
            _lastStep = null;
            
            if (!_tutorialSteps.TryGetValue(tutorialType, out TutorialStep step))
            {
                TutorialContainer.TutorialWindow.Close();
                return;
            }
            
            _lastStep = step;
            step.OnStart();
        }

        public void Reset()
        {
            _lastStep = null;
            StepSwitched?.Invoke(TutorialType.None);
        }

        public bool IsTutorialFinished(TutorialType tutorialType)
        {
            return _tutorialSteps[tutorialType].IsFinished;
        }

        private T CreateStep<T>() where T : TutorialStep
        {
            var step = _uiFactory.CreateTutorialStep<T>(TutorialContainer.transform, Vector3.zero, Quaternion.identity);
            _tutorialSteps[step.TutorialType] = step;
            step.Init(this);
            step.AddToData();
            return step;
        }
    }
}