using System;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialRunner
    {
        private AbstractTutorialStep _lastStep;
        private UIFactory _uiFactory;

        public TutorialContainer TutorialContainer { get; private set; }

        public event Action<TutorialType> TutorialSwitched; 

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
            TutorialSwitched?.Invoke(_lastStep.TutorialType);
            _lastStep = null;
            
            if (tutorialType == TutorialType.None)
            {
                TutorialContainer.TutorialWindow.Close();
                return;
            }
            
            _lastStep = CreateStep(tutorialType);
            _lastStep.OnStart();
        }

        private AbstractTutorialStep CreateStep(TutorialType tutorialType)
        {
            AbstractTutorialStep step = _uiFactory.CreateTutorialStepView(tutorialType, TutorialContainer.transform, Vector3.zero, Quaternion.identity, this);
            return step;
        }
    }
}