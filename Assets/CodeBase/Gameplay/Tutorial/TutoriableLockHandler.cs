using System;
using System.Collections.Generic;
using CodeBase.Enums;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutoriableLockHandler : MonoBehaviour
    {
        public List<TutorialType> LockTutorialStepTypes;

        private Tutoriable _tutoriable;
        private TutorialRunner _tutorialRunner;

        [Inject]
        private void Construct(TutorialRunner tutorialRunner)
        {
            _tutorialRunner = tutorialRunner;
        }

        private void Awake()
        {
            _tutoriable = GetComponent<Tutoriable>();
        }

        private void OnEnable()
        {
            _tutorialRunner.StepSwitched += OnStepSwitched;
        }

        private void OnDisable()
        {
            _tutorialRunner.StepSwitched -= OnStepSwitched;
        }

        private void OnStepSwitched(TutorialType tutorialType)
        {
            if (LockTutorialStepTypes.Contains(tutorialType))
            {
                _tutoriable.Lock();
                return;
            }

            _tutoriable.UnLock();
        }
    }
}