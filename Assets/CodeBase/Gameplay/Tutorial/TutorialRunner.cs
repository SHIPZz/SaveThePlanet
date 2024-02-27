using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialRunner
    {
        private Dictionary<TutorialType, TutorialStep> _tutorialSteps = new();
        private TutorialStep _lastStep;
        private UIFactory _uiFactory;

        public TutorialContainer TutorialContainer { get; private set; }

        public TutorialRunner(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Init(TutorialContainer tutorialContainer)
        {
            TutorialContainer = tutorialContainer;
        }
        
        public void SetStep(TutorialType tutorialType)
        {
            _lastStep?.OnFinished();
            _lastStep = CreateStep(tutorialType);
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

        private TutorialStep CreateStep(TutorialType tutorialType)
        {
            TutorialStep step = _uiFactory.CreateTutorialStepView(tutorialType, TutorialContainer.transform, Vector3.zero, Quaternion.identity, this);
            _tutorialSteps[step.TutorialType] = step;

            return step;
        }
    }
}