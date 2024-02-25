using System;
using CodeBase.Animations;
using CodeBase.Gameplay.Tutorial;
using CodeBase.UI.FrameMessage;
using CodeBase.UI.Windows.Hud;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Windows.Tutorial
{
    public class TutorialWindow : WindowBase, ITutorial
    {
        public TransformScaleAnim SkipButtonScaleAnim;
        public TutorialContainer TutorialContainer;
        
        public Button SkipButton;
        private TutorialRunner _tutorialRunner;

        public Transform Anchor => transform;
        
        public event Action SkipButtonClicked;

        [Inject]
        private void Construct(TutorialRunner tutorialRunner)
        {
            _tutorialRunner = tutorialRunner;
        }
        
        private void OnDisable()
        {
            SkipButton.onClick.RemoveListener(OnSkipButtonClicked);
        }

        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
            SkipButton.onClick.AddListener(OnSkipButtonClicked);
            _tutorialRunner.Init(TutorialContainer);
            _tutorialRunner.SetStep<InitialTutorialStep>();
        }

        public override void Close()
        {
            print("close");
            WindowService.Open<HudWindow>();
            base.Close();
        }

        private void OnSkipButtonClicked()
        {
            SkipButtonClicked?.Invoke();
        }
    }

    public interface ITutorial
    {
        Transform Anchor { get; }
    }
}