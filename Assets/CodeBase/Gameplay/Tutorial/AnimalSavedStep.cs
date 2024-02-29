using CodeBase.Enums;
using CodeBase.Services.Providers.GameProviders;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class AnimalSavedStep : AbstractTutorialStep
    {
        private GameProvider _gameProvider;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }

        public override void OnStart()
        {
            ShowSkipButton();
            ShowMessage();
        }

        public override void OnFinished()
        {
            _gameProvider.GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType.WaterSpawnZone).Init();
            base.OnFinished();
        }
    }
}