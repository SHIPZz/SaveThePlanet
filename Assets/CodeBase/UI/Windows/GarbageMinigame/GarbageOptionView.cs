using CodeBase.Animations;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageOptionView : MonoBehaviour
    {
        public GarbageInfoPopupView GarbageInfoPopupView;
        public CanvasAnimator CanvasAnimator;
        
        public void Start()
        {
            CanvasAnimator.FadeInCanvas();
        }
    }
}