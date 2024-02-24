using Agava.YandexGames;
using CodeBase.UI.Windows.Hud;
using CodeBase.UI.Windows.Joystick;
using CodeBase.UI.Windows.Pause;
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

        public UIService(WindowService windowService)
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