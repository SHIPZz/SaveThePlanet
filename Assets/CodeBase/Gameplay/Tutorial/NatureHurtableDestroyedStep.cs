using System;
using CodeBase.Enums;
using CodeBase.Services.Providers.GameProviders;
using DG.Tweening;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class NatureHurtableDestroyedStep : TutorialStep
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
            TutorialMessageController.ShowFirstMessage();

            DOTween.Sequence().AppendInterval(ShowButtonDelay)
                .OnComplete(() => TutorialContainer.SkipButtonScaleAnim.ToScale()).SetUpdate(true);

            TutorialContainer.SkipButtonClicked += ShowMessage;
        }

        public override void OnFinished()
        {
            SetCompleteToData(true);
            
            ITutoriable tutoriable = _gameProvider.GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType.AnimalSpawnZone);
            tutoriable.Init();
            TutorialRunner.TrySwitchToNextStep(TutorialType.None);
        }

        private void ShowMessage()
        {
            TutorialMessageController.TryShowNextMessage(OnFinished, null,
                () => TutorialContainer.SkipButtonScaleAnim.UnScaleAndScale());
        }
    }
}