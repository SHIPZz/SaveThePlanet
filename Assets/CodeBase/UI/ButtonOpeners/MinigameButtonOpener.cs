namespace CodeBase.UI.ButtonOpeners
{
    public class MinigameButtonOpener : ButtonOpenerBase
    {
        protected override void Open()
        {
            WindowService.Open<GarbageMinigameWindow>();
        }
    }
}