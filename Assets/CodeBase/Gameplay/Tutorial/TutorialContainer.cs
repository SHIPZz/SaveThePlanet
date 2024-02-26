using System;
using CodeBase.Animations;
using CodeBase.UI.Windows.Tutorial;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialContainer : MonoBehaviour
    {
        public Button SkipButton;
        public TransformScaleAnim SkipButtonScaleAnim;
        public TutorialWindow TutorialWindow;

        public event Action SkipButtonClicked;

        private void OnEnable()
        {
            SkipButton.onClick.AddListener(OnSkipButtonClicked);
        }

        private void OnDisable()
        {
            SkipButton.onClick.RemoveListener(OnSkipButtonClicked);
        }

        private void OnSkipButtonClicked()
        {
            SkipButtonClicked?.Invoke();
        }
    }
}