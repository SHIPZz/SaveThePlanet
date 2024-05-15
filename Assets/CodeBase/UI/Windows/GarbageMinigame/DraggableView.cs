using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class DraggableView : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Vector2 _startPosition;
        private Transform _startParent;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition;
            _startParent = _rectTransform.parent;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition = _startPosition;
        }
    }
}