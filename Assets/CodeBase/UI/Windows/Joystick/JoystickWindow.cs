using UnityEngine;

namespace CodeBase.UI.Windows.Joystick
{
    public class JoystickWindow : WindowBase
    {
        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
        }
    }
}