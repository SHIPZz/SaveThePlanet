using System;
using CodeBase.Services.WorldData;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Save
{
    public class SaveOnApplicationFocusChanged : IInitializable, IDisposable
    {
        private readonly IWorldDataService _worldDataService;

        public SaveOnApplicationFocusChanged(IWorldDataService worldDataService)
        {
            _worldDataService = worldDataService;
        }

        public void Initialize() => 
            Application.focusChanged += SaveData;

        public void Dispose() => 
            Application.focusChanged -= SaveData;

        private void SaveData(bool hasFocus)
        {
            if (!hasFocus)
                _worldDataService.Save();
        }
    }
}