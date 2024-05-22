using CodeBase.Services.Factories;
using CodeBase.Services.StaticData;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageMinigameFactory
    {
        private UIStaticDataService _uiStaticDataService;
        private UIFactory _uiFactory;

        public GarbageMinigameFactory(UIStaticDataService uiStaticDataService, UIFactory uiFactory)
        {
            _uiStaticDataService = uiStaticDataService;
            _uiFactory = uiFactory;
        }
    }
}