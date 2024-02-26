using System;
using CodeBase.Enums;
using CodeBase.Gameplay.DoDestroySystem;
using CodeBase.Services.Factories;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.Services.WorldData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    [RequireComponent(typeof(DoDestroy))]
    [RequireComponent(typeof(TutorialMessageController))]
    public abstract class TutorialStep : MonoBehaviour
    {
        [field: SerializeField] public TutorialType TutorialType { get; protected set; }
        
        protected UIFactory UIFactory;
        protected WindowService WindowService;
        protected IWorldDataService WorldDataService;
        protected TutorialRunner TutorialRunner;
        protected UIStaticDataService UiStaticDataService;
        protected DoDestroy DoDestroy;
        protected TutorialContainer TutorialContainer;
        protected TutorialMessageController TutorialMessageController;

        public bool IsFinished { get; protected set; }

        [Inject]
        private void Construct(UIFactory uiFactory, WindowService windowService, IWorldDataService worldDataService, UIStaticDataService uiStaticDataService)
        {
            UiStaticDataService = uiStaticDataService;
            UIFactory = uiFactory;
            WindowService = windowService;
            WorldDataService = worldDataService;
        }

        protected virtual void Awake()
        {
            DoDestroy = GetComponent<DoDestroy>();
            TutorialMessageController = GetComponent<TutorialMessageController>();
        }

        public virtual void Init(TutorialRunner tutorialRunner)
        {
            TutorialRunner = tutorialRunner;
            TutorialContainer = TutorialRunner.TutorialContainer;
        }

        public void AddToData()
        {
            WorldDataService.WorldData.TutorialData.CompletedTutorials.TryAdd(TutorialType, false);
        }

        public abstract void OnStart();

        public virtual void OnFinished()
        {
            
        }

        protected void SetCompleteToData(bool isCompleted)
        {
            WorldDataService.WorldData.TutorialData.CompletedTutorials[TutorialType] = isCompleted;
        }

        protected virtual bool IsCompleted()
        {
            return WorldDataService.WorldData.TutorialData.CompletedTutorials[TutorialType];
        }
    }
}