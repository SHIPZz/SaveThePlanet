using System;
using CodeBase.Animations;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.FrameMessage
{
    [RequireComponent(typeof(TransformScaleAnim))]
    public class FrameMessageView : MonoBehaviour
    {
        public TMP_Text MessageText;

        private TransformScaleAnim _transformScaleAnim;

        public event Action Shown;

        private void Awake()
        {
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        public void Show(Action onComplete = null)
        {
            _transformScaleAnim.ToScale(onComplete);
            Shown?.Invoke();
        }

        public void Hide(Action onComplete = null)
        {
            _transformScaleAnim.UnScale(onComplete);
        }
    }
}