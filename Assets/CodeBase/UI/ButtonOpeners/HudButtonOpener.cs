using CodeBase.UI.Windows.Hud;

namespace CodeBase.UI.ButtonOpeners
{
    public class HudButtonOpener : ButtonOpenerBase 
    {
        protected override void Open()
        {
            WindowService.Open<HudWindow>();
        }
    }
}