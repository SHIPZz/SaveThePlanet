using CodeBase.Animations;
using CodeBase.UI.Windows;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.GoldPopup
{
    public class GoldPopupWindow : WindowBase
    {
        [SerializeField] private TransformScaleAnim _buttonScaleAnim;
        [SerializeField] private TMP_Text _message;
        
        public override void Open()
        {
            _buttonScaleAnim.ToScaleAsync().Forget();
            CanvasAnimator.FadeInCanvas();
        }

        public void SetMessage(string message) => _message.text = message;
    }
}