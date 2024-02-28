using System;
using CodeBase.Animations;
using CodeBase.Enums;
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
    public class TutorialWindow : WindowBase
    {
        public TransformScaleAnim SkipButtonScaleAnim;
        public TutorialContainer TutorialContainer;

        public Button SkipButton;

        public Transform Anchor => transform;

        public event Action SkipButtonClicked;

        private void OnDisable()
        {
            SkipButton.onClick.RemoveListener(OnSkipButtonClicked);
        }

        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
            WindowService.Close<HudWindow>();
            SkipButton.onClick.AddListener(OnSkipButtonClicked);
        }
        
        public override void Close()
        {
            WindowService.Open<HudWindow>();
            base.Close();
        }

        private void OnSkipButtonClicked()
        {
            SkipButtonClicked?.Invoke();
        }
    }
}