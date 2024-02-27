using CodeBase.Enums;
using CodeBase.Services.Providers.GameProviders;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class AnimalSavedStep : AbstractTutorialStep
    {
        private GameProvider _gameProvider;
        private ITutoriable _tutoriable;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }

        private void OnDisable()
        {
            _tutoriable.Completed -= OnFinished;
        }

        public override void OnStart()
        {
            _tutoriable = _gameProvider.GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType.AnimalSpawnZone);
            ShowSkipButton();
            ShowMessage();
            _tutoriable.Completed += OnFinished;
        }
    }
}