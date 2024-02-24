using CodeBase.Enums;
using CodeBase.Services.Factories;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.Services.WorldData;

namespace CodeBase.Gameplay.Tutorial
{
    public abstract class TutorialStep 
    {
        protected UIFactory UIFactory;
        protected WindowService WindowService;
        protected IWorldDataService WorldDataService;
        protected TutorialRunner TutorialRunner;
        protected UIStaticDataService UiStaticDataService;

        public abstract TutorialType TutorialType { get; }

        public bool IsFinished { get; protected set; }

        protected TutorialStep(UIFactory uiFactory, WindowService windowService, IWorldDataService worldDataService, UIStaticDataService uiStaticDataService)
        {
            UiStaticDataService = uiStaticDataService;
            UIFactory = uiFactory;
            WindowService = windowService;
            WorldDataService = worldDataService;
        }

        public void SetTutorialRunner(TutorialRunner tutorialRunner) => 
            TutorialRunner = tutorialRunner;

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