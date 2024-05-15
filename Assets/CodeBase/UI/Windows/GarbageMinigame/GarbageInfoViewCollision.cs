using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageInfoViewCollision : MonoBehaviour
    {
        private GarbageMinigameSelectService _garbageMinigameSelectService;
        private GarbageInfoPopupView _garbageInfoPopupView;

        private void Awake() => 
            _garbageInfoPopupView = GetComponent<GarbageInfoPopupView>();

        [Inject]
        private void Construct(GarbageMinigameSelectService garbageMinigameSelectService)
        {
            _garbageMinigameSelectService = garbageMinigameSelectService;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _garbageMinigameSelectService.NotifyGarbageViewCollision(other,_garbageInfoPopupView);
        }
    }
}