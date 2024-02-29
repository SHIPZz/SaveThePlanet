using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.Services.WorldData;
using CodeBase.UI.Windows.Tutorial;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialService : IInitializable, IDisposable
    {
        private readonly TutorialRunner _tutorialRunner;
        private readonly WindowService _windowService;
        private readonly IWorldDataService _worldDataService;
        private readonly List<TutorialType> _tutorialQueue;

        public TutorialService(TutorialRunner tutorialRunner, WindowService windowService,
            IWorldDataService worldDataService, UIStaticDataService uiStaticDataService)
        {
            _worldDataService = worldDataService;
            _tutorialRunner = tutorialRunner;
            _windowService = windowService;
            _tutorialQueue = uiStaticDataService.Get().ReadonlyTutorialQueue.ToList();
        }

        public void Initialize()
        {
            _tutorialRunner.TutorialSwitched += SetLastStep;

            Dictionary<TutorialType, bool> completedTutorials =
                _worldDataService.WorldData.TutorialData.CompletedTutorials;

            foreach (TutorialType tutorialType in _tutorialQueue)
            {
                completedTutorials.TryAdd(tutorialType, false);
            }

            _worldDataService.WorldData.TutorialData.CompletedTutorials = completedTutorials;
        }

        public void Dispose()
        {
            _tutorialRunner.TutorialSwitched -= SetLastStep;
        }

        public bool TryExecuteLastTutorial()
        {
            if (_worldDataService.WorldData.TutorialData.Completed)
                return false;
            
            var tutorialWindow = _windowService.Get<TutorialWindow>();
            _tutorialRunner.Init(tutorialWindow.TutorialContainer);
            _tutorialRunner.SetStep(_worldDataService.WorldData.TutorialData.LastTutorial);
            _windowService.OpenCurrentWindow();
            return true;
        }

        public bool TryExecute(TutorialType tutorialType)
        {
            if (_worldDataService.WorldData.TutorialData.Completed)
                return false;

            if (_worldDataService.WorldData.TutorialData.CompletedTutorials.TryGetValue(tutorialType,
                    out bool finished))
                if (finished)
                    return false;

            var tutorialWindow = _windowService.Get<TutorialWindow>();
            _tutorialRunner.Init(tutorialWindow.TutorialContainer);
            _tutorialRunner.SetStep(tutorialType);
            _windowService.OpenCurrentWindow();
            return true;
        }

        public bool Completed(TutorialType tutorialType)
        {
            if (_worldDataService.WorldData.TutorialData.CompletedTutorials.TryGetValue(tutorialType, out var completed))
                return completed;

            return false;
        }

        public bool TutorialCompleted() =>
            _worldDataService.WorldData.TutorialData.Completed;

        public void SetCompleted(TutorialType tutorialType, bool isCompleted)
        {
            _worldDataService.WorldData.TutorialData.CompletedTutorials[tutorialType] = isCompleted;
        }

        public void SetLastStep(TutorialType tutorialType)
        {
            _worldDataService.WorldData.TutorialData.LastTutorial = tutorialType;
            int index = _tutorialQueue.IndexOf(tutorialType);

            if (index != -1 && index < _tutorialQueue.Count - 1)
            {
                TutorialType nextTutorialType = _tutorialQueue[index + 1];
            }
        }
    }
}