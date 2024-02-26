using System;
using CodeBase.Enums;
using CodeBase.Services.UI;
using CodeBase.UI.Windows.Tutorial;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class InvokeTargetTutorialOnCompleted : MonoBehaviour
    {
        public TutorialType TutorialType;

        private ITutoriable _tutoriable;
        private WindowService _windowService;

        [Inject]
        private void Construct(WindowService windowService)
        {
            _windowService = windowService;
        }

        private void Awake()
        {
            _tutoriable = GetComponent<ITutoriable>();
        }

        private void OnEnable()
        {
            _tutoriable.Completed += OnCompleted;
        }

        private void OnDisable()
        {
            _tutoriable.Completed -= OnCompleted;
        }

        [Button]
        private void OnCompleted()
        {
           var tutorialWindow = _windowService.Get<TutorialWindow>();
           tutorialWindow.Init(TutorialType);
           _windowService.OpenCurrentWindow();
        }
    }
}