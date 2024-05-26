using System;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageInfoViewCollision : MonoBehaviour
    {
        private GarbageMinigameService _garbageMinigameService;
        private GarbageInfoPopupView _garbageInfoPopupView;

        private void Awake() => 
            _garbageInfoPopupView = GetComponent<GarbageInfoPopupView>();

        [Inject]
        private void Construct(GarbageMinigameService garbageMinigameService)
        {
            _garbageMinigameService = garbageMinigameService;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print($"TRIGGER: {other.gameObject.name}");
            _garbageMinigameService.NotifyGarbageViewCollision(other,_garbageInfoPopupView);
        }
    }
}