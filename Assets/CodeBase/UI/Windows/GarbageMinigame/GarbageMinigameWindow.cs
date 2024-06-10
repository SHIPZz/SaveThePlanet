using System;
using CodeBase.UI.GoldPopup;
using CodeBase.UI.Windows;
using CodeBase.UI.Windows.GarbageMinigame;
using CodeBase.UI.Windows.Hud;
using CodeBase.UI.Windows.Pause;
using UniRx;
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
        _garbageMinigameService.MinigameFinished.Subscribe(_ => OpenPopup());
        _garbageMinigameService.Init(GarbageOptionParent, GarbageAnswerParent,_canvas);
    }

    private void OpenPopup()
    {
       var goldPopup =  WindowService.OpenAndGet<GoldPopupWindow>();
       goldPopup.SetMessage("Congratulations on completing the mini-game! Your environmental knowledge has improved significantly!");
        Close();
    }

    public override void Close()
    {
        _garbageMinigameService.CleanUp();
        WindowService.Open<HudWindow>();
        base.Close();
    }
}
