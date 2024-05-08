using CodeBase.Animations;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.GoldPopup
{
    public class GoldPopupWindow : WindowBase
    {
        [SerializeField] private TransformScaleAnim _buttonScaleAnim;
        
        public override void Open()
        {
            _buttonScaleAnim.ToScaleAsync().Forget();
            CanvasAnimator.FadeInCanvas();
        }
    }
}