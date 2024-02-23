using CodeBase.Animations;
using CodeBase.Services.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Windows
{
    [RequireComponent(typeof(CanvasAnimator))]
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] protected Button CloseButton;
        [SerializeField] protected CanvasAnimator CanvasAnimator;
        
        protected WindowService WindowService;

        [Inject]
        private void Construct(WindowService windowService) => 
            WindowService = windowService;

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
