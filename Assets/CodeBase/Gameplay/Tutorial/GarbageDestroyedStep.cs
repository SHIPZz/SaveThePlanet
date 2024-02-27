using System;
using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.Gameplay.NatureHurtables;
using CodeBase.Services.Providers.GameProviders;
using CodeBase.UI.FrameMessage;
using DG.Tweening;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class GarbageDestroyedStep : TutorialStep
    {
        public float ShowButtonDelay = 2f;

        private GameProvider _gameProvider;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }

        public override void OnStart()
        {
            _tutorialMessageDisplay.TryShowNextMessage();

            DOTween.Sequence().AppendInterval(ShowButtonDelay)
                .OnComplete(() => TutorialContainer.SkipButtonScaleAnim.ToScale()).SetUpdate(true);

            TutorialContainer.SkipButtonClicked += ShowMessage;
        }

        public override void OnFinished()
        {
            SetCompleteToData(true);
            ITutoriable tutoriable = _gameProvider.GetTutoriable<NatureHurtableSpawner>();
            tutoriable.Init();
            TutorialRunner.TrySwitchToNextStep(TutorialType.None);
        }

        private void ShowMessage()
        {
            _tutorialMessageDisplay.TryShowNextMessage(OnFinished, () => TutorialContainer.SkipButtonScaleAnim.UnScaleAndScale());
        }
    }
}