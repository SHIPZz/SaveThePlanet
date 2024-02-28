using CodeBase.Enums;
using CodeBase.Services.UI;
using CodeBase.Services.WorldData;
using CodeBase.UI.Windows.Tutorial;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialService
    {
        private readonly TutorialRunner _tutorialRunner;
        private readonly WindowService _windowService;
        private readonly IWorldDataService _worldDataService;

        public TutorialService(TutorialRunner tutorialRunner, WindowService windowService,
            IWorldDataService worldDataService)
        {
            _worldDataService = worldDataService;
            _tutorialRunner = tutorialRunner;
            _windowService = windowService;
        }

        public bool TryExecute(TutorialType tutorialType)
        {
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
    }
}