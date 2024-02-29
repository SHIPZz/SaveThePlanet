using System;
using CodeBase.Enums;
using CodeBase.Gameplay.DoDestroySystem;
using CodeBase.Services.WorldData;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    [RequireComponent(typeof(DoDestroy))]
    [RequireComponent(typeof(TutorialMessageDisplay))]
    public abstract class AbstractTutorialStep : MonoBehaviour
    {
        [field: SerializeField] public TutorialType TutorialType { get; protected set; }
        [field: SerializeField] public TutorialType NextTutorialType { get; protected set; } = TutorialType.None;
        [SerializeField] protected float ShowButtonDelay = 1.5f;

        protected IWorldDataService WorldDataService;
        protected TutorialRunner TutorialRunner;
        protected DoDestroy DoDestroy;
        protected TutorialContainer TutorialContainer;
        protected TutorialMessageDisplay TutorialMessageDisplay;

        [Inject]
        private void Construct(IWorldDataService worldDataService)
        {
            WorldDataService = worldDataService;
        }

        protected virtual void Awake()
        {
            DoDestroy = GetComponent<DoDestroy>();
            TutorialMessageDisplay = GetComponent<TutorialMessageDisplay>();
        }

        public virtual void Init(TutorialRunner tutorialRunner)
        {
            TutorialRunner = tutorialRunner;
            TutorialContainer = TutorialRunner.TutorialContainer;
            TutorialContainer.SkipButtonClicked += ShowMessage;
        }

        private void OnDisable()
        {
            TutorialContainer.SkipButtonClicked -= ShowMessage;
        }

        public void AddToData()
        {
            WorldDataService.WorldData.TutorialData.CompletedTutorials.TryAdd(TutorialType, false);
        }

        public abstract void OnStart();

        public virtual void OnFinished()
        {
            TutorialRunner.TrySwitchToNextStep(NextTutorialType);
            DoDestroy.Do();
        }

        public void SetCompleteToData(bool isCompleted)
        {
            WorldDataService.WorldData.TutorialData.Completed = isCompleted;
            WorldDataService.Save();
        }

        protected void ShowSkipButton()
        {
            DOTween.Sequence().AppendInterval(ShowButtonDelay).OnComplete(() =>
                TutorialContainer.SkipButtonScaleAnim.ToScale()).SetUpdate(true);
        }

        protected virtual void ShowMessage()
        {
            TutorialMessageDisplay.TryShowNextMessage(OnFinished);
        }
    }
}