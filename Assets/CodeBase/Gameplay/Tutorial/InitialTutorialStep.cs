using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.InfraStructure;
using CodeBase.Services.Providers.GameProviders;
using DG.Tweening;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class InitialTutorialStep : TutorialStep
    {
        public float ScaleSkipButtonDelay = 3.5f;
        public float ShowMessageDelay = 2f;

        private ILoadingCurtain _loadingCurtain;
        private GameProvider _gameProvider;

        [Inject]
        private void Construct(ILoadingCurtain loadingCurtain, GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
            _loadingCurtain = loadingCurtain;
        }

        private void Start() =>
            _loadingCurtain.Closed += ShowMessageView;

        private void OnDisable()
        {
            _loadingCurtain.Closed -= ShowMessageView;
            TutorialContainer.SkipButtonClicked -= ShowNextMessage;
        }

        public override void Init(TutorialRunner tutorialRunner)
        {
            base.Init(tutorialRunner);

            TutorialContainer.SkipButtonClicked += ShowNextMessage;
        }

        public override void OnStart() =>
            DOTween.Sequence().AppendInterval(ScaleSkipButtonDelay).OnComplete(() =>
                TutorialContainer.SkipButtonScaleAnim.ToScale()).SetUpdate(true);

        public override void OnFinished()
        {
            TutorialContainer.SkipButtonScaleAnim.UnScale();
            TutorialRunner.TrySwitchToNextStep(TutorialType.None);
            SetCompleteToData(true);
            ITutoriable tutoriable = _gameProvider.GetTutoriable<GarbageSpawnZoneStarter>();
            tutoriable.Init();
            DoDestroy.Do();
        }

        private void ShowMessageView() =>
            DOTween.Sequence().AppendInterval(ShowMessageDelay)
                .OnComplete(() => _tutorialMessageDisplay.TryShowNextMessage())
                .SetUpdate(true);

        private void ShowNextMessage() =>
            _tutorialMessageDisplay.TryShowNextMessage(OnFinished);
    }
}