using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialRunner : IDisposable
    {
        private readonly IInstantiator _instantiator;

        private Dictionary<TutorialType, TutorialStep> _tutorialSteps = new();
        private TutorialStep _lastStep;

        public event Action<TutorialType> StepSwitched;

        public TutorialRunner(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public void Dispose()
        {
            foreach (TutorialStep tutorialStep in _tutorialSteps.Values)
            {
                IDisposable disposable = tutorialStep as IDisposable;
                disposable?.Dispose();
            }
        }

        public void SetStep<T>() where T : TutorialStep
        {
            _lastStep?.OnFinished();
            _lastStep = CreateStep<T>();
            _lastStep.OnStart();
            StepSwitched?.Invoke(_lastStep.TutorialType);
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

        private TutorialStep CreateStep<T>() where T : TutorialStep
        {
            var step = _instantiator.Instantiate<T>();
            step.SetTutorialRunner(this);
            step.AddToData();
            _tutorialSteps[step.TutorialType] = step;
            return step;
        }
    }
}