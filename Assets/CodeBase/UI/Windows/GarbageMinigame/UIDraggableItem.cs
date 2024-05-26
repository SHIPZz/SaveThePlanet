using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class UIDraggableItem : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private Vector2 _startPosition;
        private RectTransform _rectTransform;
        private UnityEngine.Canvas _canvas;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Init(UnityEngine.Canvas canvas) =>
            _canvas = canvas;

        public void OnDrag(PointerEventData eventData) => 
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        public void OnBeginDrag(PointerEventData eventData) => 
            _canvasGroup.blocksRaycasts = false;

        public void OnEndDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition = _startPosition;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}