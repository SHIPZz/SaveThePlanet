using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.InfraStructure;
using CodeBase.Services.Providers.GameProviders;
using CodeBase.UI.FrameMessage;
using DG.Tweening;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class InitialTutorialStep : TutorialStep
    {
        public List<FrameMessageView> FrameMessageViews;

        public float ScaleSkipButtonDelay = 3.5f;
        public float ShowMessageDelay = 2f;

        private FrameMessageView _lastMessageView;
        private int _id = -1;
        private Button _skipButton;
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
            _skipButton.onClick.RemoveListener(TryShowNextMessage);
            _loadingCurtain.Closed -= ShowMessageView;
        }

        public override void Init(TutorialRunner tutorialRunner)
        {
            base.Init(tutorialRunner);

            _skipButton = TutorialRunner.TutorialContainer.SkipButton;
            _skipButton.onClick.AddListener(TryShowNextMessage);
        }

        public override void OnStart()
        {
            _id++;
            _lastMessageView = FrameMessageViews[_id];

            DOTween.Sequence().AppendInterval(ScaleSkipButtonDelay).OnComplete(() =>
                TutorialRunner.TutorialContainer.SkipButtonScaleAnim.ToScale()).SetUpdate(true);
        }

        public override void OnFinished()
        {
            TutorialRunner.TutorialContainer.SkipButtonScaleAnim.UnScale();
            TutorialRunner.TrySwitchToNextStep(TutorialType.None);
            var garbageSpawnZone = _gameProvider.CameraPans[CameraPanType.GarbageSpawnZone].GetComponent<GarbageSpawnZoneStarter>();
            garbageSpawnZone.Init();
            DoDestroy.Do();
        }

        private void ShowMessageView() =>
            DOTween.Sequence().AppendInterval(ShowMessageDelay).OnComplete(() => _lastMessageView.Show())
                .SetUpdate(true);

        private void TryShowNextMessage()
        {
            _id++;

            TryHideSkipButtonOnFinishedMessages();

            if (_id > FrameMessageViews.Count - 1)
            {
                OnFinished();
                return;
            }

            _lastMessageView?.Hide(() =>
            {
                _lastMessageView = FrameMessageViews[_id];
                _lastMessageView.Show();
            });
        }

        private void TryHideSkipButtonOnFinishedMessages()
        {
            var tempId = _id;

            tempId++;

            if (tempId > FrameMessageViews.Count)
                TutorialRunner.TutorialContainer.SkipButtonScaleAnim.UnScale();
        }
    }
}