using CodeBase.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    [RequireComponent(typeof(CanvasAnimator))]
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] protected Button CloseButton;
        [SerializeField] protected CanvasAnimator CanvasAnimator;

        private void Awake()
        {
            if (CloseButton != null)
                CloseButton.onClick.AddListener(Close);
        }

        public abstract void Open();

        public virtual void Close()
        {
            Destroy(gameObject);
        }

        public virtual void Show()
        {
            
        }

        public virtual void Hide()
        {
            
        }
    }
}
