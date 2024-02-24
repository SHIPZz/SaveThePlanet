using System;
using CodeBase.Enums;
using CodeBase.ScriptableObjects.Tutorial;
using CodeBase.Services.Factories;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.Services.WorldData;
using CodeBase.UI.Windows.Tutorial;

namespace CodeBase.Gameplay.Tutorial
{
    public class InitialTutorialStep : TutorialStep, IDisposable
    {
        private TutorialWindow _tutorialWindow;

        public override TutorialType TutorialType => TutorialType.InitialTutorial;

        public InitialTutorialStep(UIFactory uiFactory, WindowService windowService, IWorldDataService worldDataService,
            UIStaticDataService uiStaticDataService)
            : base(uiFactory, windowService, worldDataService, uiStaticDataService) { }

        public override void OnStart()
        {
            TutorialSO tutorialData = UiStaticDataService.Get(TutorialType);
            _tutorialWindow = WindowService.Get<TutorialWindow>();
            _tutorialWindow.SetTextToFrameMessage(tutorialData.Text);
            WindowService.OpenCurrentWindow();
            _tutorialWindow.ScaleSkipButton(3f);
            _tutorialWindow.SkipButtonClicked += OnFinished;
        }

        public override void OnFinished()
        {
            IsFinished = true;
            SetCompleteToData(true);
            TutorialRunner.Reset();
            Dispose();
        }

        public void Dispose()
        {
            if (_tutorialWindow != null)
                _tutorialWindow.SkipButtonClicked -= OnFinished;
        }
    }
}