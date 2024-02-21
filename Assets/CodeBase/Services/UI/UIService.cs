using Agava.YandexGames;
using CodeBase.UI.Windows.Joystick;
using UnityEngine;
using YG;
using Zenject;

namespace CodeBase.Services.UI
{
    public class UIService : IInitializable
    {
        private readonly WindowService _windowService;

        public UIService(WindowService windowService)
        {
            _windowService = windowService;
        }

        public void Initialize()
        {
#if UNITY_WEBGL
            if (YandexGame.EnvironmentData.deviceType == "mobile")
            {
                _windowService.Open<JoystickWindow>();
            }
#endif
            
        }
    }
}