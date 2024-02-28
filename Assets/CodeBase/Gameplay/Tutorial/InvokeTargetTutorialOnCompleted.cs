using CodeBase.Enums;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class InvokeTargetTutorialOnCompleted : MonoBehaviour
    {
        public TutorialType TutorialType;
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
            if (_tutorialService.Completed(TutorialType))
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
                .OnComplete(() => _tutorialService.TryExecute(TutorialType)).SetUpdate(true);
        }
    }
}