using CodeBase.Enums;
using CodeBase.Services.WorldData;
using UnityEngine;

namespace CodeBase.Services.Warning
{
    public class WarningDataService
    {
        private readonly IWorldDataService _worldDataService;

        public WarningDataService(IWorldDataService worldDataService)
        {
            _worldDataService = worldDataService;
        }

        public void SetShownWarning(WarningItemType warningItemType, bool isShown)
        {
            _worldDataService.WorldData.TutorialData.ShownWarnings[warningItemType] = true;
        }

        public bool HasShown(WarningItemType warningItemType) => 
            _worldDataService.WorldData.TutorialData.ShownWarnings.ContainsKey(warningItemType) && 
            _worldDataService.WorldData.TutorialData.ShownWarnings[warningItemType];
    }
}