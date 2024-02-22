using UnityEngine.UI;

namespace CodeBase.UI.Windows.Hud
{
    public class HudWindow : WindowBase
    {
        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
        }
    }
}