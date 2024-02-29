using CodeBase.Enums;
using CodeBase.Services.Providers.GameProviders;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class NatureHurtableDestroyedStep : AbstractTutorialStep
    {
        private GameProvider _gameProvider;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }

        public override void OnStart()
        {
            TutorialMessageDisplay.TryShowNextMessage();
            
            ShowSkipButton();
        }

        public override void OnFinished()
        {
            ITutoriable tutoriable = _gameProvider.GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType.AnimalSpawnZone);
            tutoriable.Init();
            base.OnFinished();
        }
    }
}