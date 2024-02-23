using CodeBase.UI.Windows.News;

namespace CodeBase.UI.ButtonOpeners
{
    public class NewsButtonOpener : ButtonOpenerBase
    {
        protected override void Open()
        {
            WindowService.Open<NewsWindow>();
        }
    }
}