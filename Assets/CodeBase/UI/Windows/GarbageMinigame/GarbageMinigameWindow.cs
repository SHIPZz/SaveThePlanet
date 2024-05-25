using CodeBase.UI.Windows;
using CodeBase.UI.Windows.GarbageMinigame;
using CodeBase.UI.Windows.Pause;
using UnityEngine;
using Zenject;

public class GarbageMinigameWindow : WindowBase
{
    public Transform GarbageOptionParent;
    public Transform GarbageAnswerParent;
    
    private GarbageMinigameService _garbageMinigameService;

    [Inject]
    private void Construct(GarbageMinigameService garbageMinigameService)
    {
        _garbageMinigameService = garbageMinigameService;
    }
    
    public override void Open()
    {
        CanvasAnimator.FadeInCanvas();
        WindowService.Close<PauseWindow>();
        _garbageMinigameService.Init(GarbageOptionParent, GarbageAnswerParent);
    }

    public override void Close()
    {
        _garbageMinigameService.CleanUp();
        WindowService.Open<PauseWindow>();
        base.Close();
    }
}
