using CodeBase.UI.Windows.Pause;

namespace CodeBase.UI.Windows.News
{
    public class NewsWindow : WindowBase
    {
        public override void Open()
        {
            WindowService.Close<PauseWindow>();
            CanvasAnimator.FadeInCanvas();
        }

        public override void Close()
        {
            WindowService.Open<PauseWindow>();
            base.Close();
        }
    }
}