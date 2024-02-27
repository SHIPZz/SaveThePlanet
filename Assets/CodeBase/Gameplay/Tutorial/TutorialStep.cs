using CodeBase.Enums;
using CodeBase.Gameplay.DoDestroySystem;
using CodeBase.Services.WorldData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    [RequireComponent(typeof(DoDestroy))]
    [RequireComponent(typeof(TutorialMessageDisplay))]
    public abstract class TutorialStep : MonoBehaviour
    {
        [field: SerializeField] public TutorialType TutorialType { get; protected set; }
        
        protected IWorldDataService WorldDataService;
        protected TutorialRunner TutorialRunner;
        protected DoDestroy DoDestroy;
        protected TutorialContainer TutorialContainer;
        protected TutorialMessageDisplay _tutorialMessageDisplay;

        [Inject]
        private void Construct(IWorldDataService worldDataService)
        {
            WorldDataService = worldDataService;
        }

        protected virtual void Awake()
        {
            DoDestroy = GetComponent<DoDestroy>();
            _tutorialMessageDisplay = GetComponent<TutorialMessageDisplay>();
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