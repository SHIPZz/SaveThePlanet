using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.InfraStructure;
using CodeBase.Services.Providers.GameProviders;
using DG.Tweening;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class InitialTutorialStep : AbstractTutorialStep
    {
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
            _loadingCurtain.Closed += ShowMessage;

        private void OnDisable() => 
            _loadingCurtain.Closed -= ShowMessage;

        public override void OnStart() =>
            ShowSkipButton();

        public override void OnFinished()
        {
            TutorialContainer.SkipButtonScaleAnim.UnScale();
            TutorialRunner.TrySwitchToNextStep(TutorialType.None);
            SetCompleteToData(true);
            ITutoriable tutoriable = _gameProvider.GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType.TreeSpawnZone);
            tutoriable.Init();
            DoDestroy.Do();
        }
    }
}