using Agava.YandexGames;
using CodeBase.Enums;
using CodeBase.Gameplay.Tutorial;
using CodeBase.UI.Windows.Hud;
using CodeBase.UI.Windows.Joystick;
using CodeBase.UI.Windows.Pause;
using CodeBase.UI.Windows.Tutorial;
using Unity.VisualScripting;
using UnityEngine;
using YG;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace CodeBase.Services.UI
{
    public class UIService
    {
        private readonly WindowService _windowService;

        public UIService(WindowService windowService, TutorialRunner tutorialRunner)
        {
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
           var tutorialWindow = _windowService.Get<TutorialWindow>();
           tutorialWindow.Init(TutorialType.InitialTutorial);
           tutorialWindow.Open();
            
            // _windowService.Open<HudWindow>();
// #if UNITY_WEBGL
//             if (YandexGame.EnvironmentData.deviceType == "mobile")
//             {
//                 _windowService.Open<JoystickWindow>();
//             }
// #endif
            
        }
    }
}