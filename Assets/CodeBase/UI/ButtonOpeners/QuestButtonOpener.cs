using CodeBase.Gameplay.Quest;

namespace CodeBase.UI.ButtonOpeners
{
    public class QuestButtonOpener : ButtonOpenerBase
    {
        protected override void Open()
        {
            WindowService.Open<QuestWindow>();
        }
    }
}