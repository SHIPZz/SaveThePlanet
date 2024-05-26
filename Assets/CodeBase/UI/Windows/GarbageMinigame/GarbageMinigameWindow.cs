using System;
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
    private Canvas _canvas;

    [Inject]
    private void Construct(GarbageMinigameService garbageMinigameService)
    {
        _garbageMinigameService = garbageMinigameService;
    }
    
    public override void Open()
    {
        CanvasAnimator.FadeInCanvas();
        WindowService.Close<PauseWindow>();
        _canvas = GetComponent<Canvas>();
        _garbageMinigameService.Init(GarbageOptionParent, GarbageAnswerParent,_canvas);
    }

    public override void Close()
    {
        _garbageMinigameService.CleanUp();
        WindowService.Open<PauseWindow>();
        base.Close();
    }
}
