using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageMinigameSelectService
    {
        public void NotifyGarbageViewCollision(Collider other, GarbageInfoPopupView garbageInfoPopupView)
        {
            if (!other.gameObject.TryGetComponent(out GarbageAnswerCellView garbageAnswerCellView))
                return;
            
            if (garbageAnswerCellView.GarbageType == garbageInfoPopupView.GarbageType)
            {
                garbageAnswerCellView.SetIcon(garbageInfoPopupView.Icon.sprite);
                garbageInfoPopupView.Parent.gameObject.SetActive(false);
            }
        }
    }
}