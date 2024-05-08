using CodeBase.UI.Windows.Hud;
using UnityEngine;

namespace CodeBase.UI.ButtonOpeners
{
    public class HudButtonOpener : ButtonOpenerBase
    {
        [SerializeField] private bool _closeAll;
        
        protected override void Open()
        {
            if(_closeAll)
                WindowService.CloseAll();
                
            WindowService.Open<HudWindow>();
        }
    }
}