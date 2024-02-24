using System;
using System.Threading;
using CodeBase.Services.UI;
using CodeBase.UI.Windows;
using CodeBase.UI.Windows.Hud;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.Services.Pause
{
    public class PauseOnWindowOpened : IInitializable, IDisposable
    {
        private readonly WindowService _windowService;
        private readonly IPauseService _pauseService;

        private CancellationTokenSource _cancellationTokenSource;

        public PauseOnWindowOpened(WindowService windowService, IPauseService pauseService)
        {
            _windowService = windowService;
            _pauseService = pauseService;
        }

        public async void Initialize()
        {
            _windowService.Opened += TryPause;

            while (_windowService.CurrentWindow == null)
            {
                await UniTask.Yield(_cancellationTokenSource.Token);
            }
            
            if(_windowService.CurrentWindow.GetType() != typeof(HudWindow))
                _pauseService.Pause();
        }

        public void Dispose()
        {
            _windowService.Opened -= TryPause;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
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