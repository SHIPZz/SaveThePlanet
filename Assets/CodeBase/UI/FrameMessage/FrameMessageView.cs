using System;
using CodeBase.Animations;
using CodeBase.Enums;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.FrameMessage
{
    [RequireComponent(typeof(TransformScaleAnim))]
    public class FrameMessageView : MonoBehaviour
    {
        public TMP_Text MessageText;
        public MessageType MessageType;

        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        public void Show(Action onComplete = null)
        {
            _transformScaleAnim.ToScale(onComplete);
        }

        public void Hide(Action onComplete = null)
        {
            _transformScaleAnim.UnScale(onComplete);
        }
    }
}