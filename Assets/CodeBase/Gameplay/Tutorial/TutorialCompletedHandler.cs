using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialCompletedHandler : MonoBehaviour
    {
        public List<TutorialType> SetFinishTutorials;
        public TutorialType TargetTutorial;
        public float InvokeDelay;

        private ITutoriable _tutoriable;
        private TutorialService _tutorialService;

        [Inject]
        private void Construct(TutorialService tutorialService)
        {
            _tutorialService = tutorialService;
        }

        private void Awake()
        {
            _tutoriable = GetComponent<ITutoriable>();
        }

        private void Start()
        {
            if (_tutorialService.TutorialCompleted())
            {
                _tutoriable.Init();
                return;
            }

            if (SetFinishTutorials.Any(tutorialType => _tutorialService.Completed(tutorialType))) 
                _tutoriable.Init();
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
            DOTween
                .Sequence()
                .AppendInterval(InvokeDelay)
                .OnComplete(OnTutoriableCompleted).SetUpdate(true);
        }

        private void OnTutoriableCompleted()
        {
            _tutorialService.TryExecute(TargetTutorial);

            foreach (TutorialType tutorialType in SetFinishTutorials)
            {
                _tutorialService.SetCompleted(tutorialType, true);
            }
        }
    }
}