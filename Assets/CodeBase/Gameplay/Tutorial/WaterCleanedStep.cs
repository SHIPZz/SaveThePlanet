using CodeBase.Enums;
using CodeBase.Gameplay.Fireables;
using CodeBase.Services.Providers.GameProviders;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class WaterCleanedStep : AbstractTutorialStep
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
            _tutoriable = _gameProvider.GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType.WaterSpawnZone);
            ShowMessage();
            ShowSkipButton();
            _tutoriable.Completed += OnFinished;
        }

        public override void OnFinished()
        {
            _tutoriable = _gameProvider.GetTutoriable<FireableSpawner>();
            _tutoriable.Init();
            base.OnFinished();
        }
    }
}