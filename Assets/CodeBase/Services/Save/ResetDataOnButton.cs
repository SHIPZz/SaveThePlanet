using CodeBase.Services.WorldData;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Save
{
    public class ResetDataOnButton : ITickable
    {
        private readonly IWorldDataService _worldDataService;

        public ResetDataOnButton(IWorldDataService worldDataService)
        {
            _worldDataService = worldDataService;
        }

        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                _worldDataService.Reset();
            }
        }
    }
}