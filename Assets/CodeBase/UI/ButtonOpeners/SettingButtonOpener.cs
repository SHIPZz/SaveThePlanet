using CodeBase.UI.Windows.Settings;

namespace CodeBase.UI.ButtonOpeners
{
    public class SettingButtonOpener : ButtonOpenerBase
    {
        protected override void Open()
        {
            WindowService.Open<SettingsWindow>();
        }
    }
}