using CodeBase.Enums;
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
            TutorialMessageDisplay.TryShowNextMessage();
            ShowSkipButton();
            TutorialContainer.SkipButtonClicked += ShowMessage;
        }

        public override void OnFinished()
        {
            SetCompleteToData(true);
            ITutoriable tutoriable = _gameProvider.GetTutoriable<NatureHurtableSpawner>();
            tutoriable.Init();
            TutorialRunner.TrySwitchToNextStep(TutorialType.None);
        }
    }
}