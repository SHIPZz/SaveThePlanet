﻿using CodeBase.Services.UI;
using CodeBase.UI.Windows.Hud;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows.Pause
{
    public class PauseWindowController : ITickable
    {
        private readonly WindowService _windowService;

        public PauseWindowController(WindowService windowService)
        {
            _windowService = windowService;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _windowService.CurrentWindow.GetType() == typeof(HudWindow))
            {
                _windowService.Close<HudWindow>();
                _windowService.Open<PauseWindow>();
            }
        }
    }
}