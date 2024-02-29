using System;
using CodeBase.Services.Camera;
using CodeBase.Services.UI;
using CodeBase.UI.Windows.Hud;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows.Pause
{
    public class PauseWindowController : IInitializable, IDisposable, ITickable, IWindowController
    {
        private readonly WindowService _windowService;
        private readonly CameraService _cameraService;

        public PauseWindowController(WindowService windowService, CameraService cameraService)
        {
            _cameraService = cameraService;
            _windowService = windowService;
        }

        public void Initialize()
        {
            Application.focusChanged += OnFocusChanged;
        }

        public void Tick()
        {
            if (_cameraService.IsMoving())
                return;

            if (!Input.GetKeyDown(KeyCode.Escape) || !_windowService.CompareCurrentWindow<HudWindow>())
                return;

            _windowService.Close<HudWindow>();
            _windowService.Open<PauseWindow>();
        }

        public void Dispose()
        {
            Application.focusChanged -= OnFocusChanged;
        }

        private void OnFocusChanged(bool hasFocus)
        {
            if (!hasFocus)
            {
                // _windowService.Open<PauseWindow>(true);
            }
        }
    }
}