using CodeBase.Gameplay.Tutorial;
using CodeBase.Services.Factories;
using CodeBase.UI.Windows.Hud;
using CodeBase.UI.Windows.Pause;
using IInitializable = Zenject.IInitializable;

namespace CodeBase.Services.UI
{
    public class UIService : IInitializable
    {
        private readonly WindowService _windowService;
        private TutorialService _tutorialService;
        private UIFactory _uiFactory;

        public UIService(WindowService windowService, TutorialService tutorialService, UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _tutorialService = tutorialService;
            _windowService = windowService;
        }

        public void CloseAllWindows()
        {
            _windowService.CloseAll();
        }

        public void OpenHud()
        {
            _windowService.Open<HudWindow>();
        }

        public void Initialize()
        {
            if (!_tutorialService.TryExecuteLastTutorial())
                _windowService.Open<HudWindow>();
            
            InitPauseWindowController();
        }

        private void InitPauseWindowController()
        {
            var pauseWindowController = _uiFactory.CreateWindowController<PauseWindowController>();
        }
    }
}