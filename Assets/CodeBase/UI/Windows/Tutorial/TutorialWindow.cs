using System;
using CodeBase.Animations;
using CodeBase.UI.FrameMessage;
using CodeBase.UI.Windows.Hud;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.Tutorial
{
    public class TutorialWindow : WindowBase
    {
        public FrameMessageView FrameMessageView;
        public TransformScaleAnim SkipButtonScaleAnim;
        public Button SkipButton;

        public event Action SkipButtonClicked;

        private void OnDisable()
        {
            SkipButton.onClick.RemoveListener(OnSkipButtonClicked);
        }

        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
            SkipButton.onClick.AddListener(OnSkipButtonClicked);
        }

        public override void Close()
        {
            WindowService.Open<HudWindow>();
            base.Close();
        }

        public void SetTextToFrameMessage(TMP_Text text)
        {
            FrameMessageView.MessageText = text;
        }

        public void ScaleSkipButton(float delay)
        {
            DOTween.Sequence().AppendInterval(delay).OnComplete(() => SkipButtonScaleAnim.ToScale()).SetUpdate(true);
        }

        private void OnSkipButtonClicked()
        {
            SkipButtonClicked?.Invoke();
        }
    }
}