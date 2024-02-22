using CodeBase.UI.Windows.Pause;

namespace CodeBase.UI.ButtonOpeners
{
    public class PauseButtonOpener : ButtonOpenerBase
    {
        protected override void Open()
        {
            WindowService.Open<PauseWindow>();
        }
    }
}