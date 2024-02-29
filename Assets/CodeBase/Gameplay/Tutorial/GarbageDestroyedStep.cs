using CodeBase.Gameplay.NatureHurtables;
using CodeBase.Services.Providers.GameProviders;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class GarbageDestroyedStep : AbstractTutorialStep
    {
        private GameProvider _gameProvider;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }

        public override void OnStart()
        {
            ShowMessage();
            ShowSkipButton();
        }

        public override void OnFinished()
        {
            ITutoriable tutoriable = _gameProvider.GetTutoriable<NatureHurtableSpawner>();
            tutoriable.Init();
            base.OnFinished();
        }
    }
}