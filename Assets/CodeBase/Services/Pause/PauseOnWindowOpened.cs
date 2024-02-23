using System;
using CodeBase.Services.UI;
using CodeBase.UI.Windows;
using CodeBase.UI.Windows.Hud;
using Zenject;

namespace CodeBase.Services.Pause
{
    public class PauseOnWindowOpened : IInitializable, IDisposable
    {
        private readonly WindowService _windowService;
        private readonly IPauseService _pauseService;

        public PauseOnWindowOpened(WindowService windowService, IPauseService pauseService)
        {
            _windowService = windowService;
            _pauseService = pauseService;
        }

        public void Initialize()
        {
            _windowService.Opened += TryPause;
        }

        public void Dispose()
        {
            _windowService.Opened -= TryPause;
        }

        private void TryPause(WindowBase window)
        {
            if (window.GetType() == typeof(HudWindow))
            {
                _pauseService.UnPause();
                return;
            }

            _pauseService.Pause();
        }
    }
}