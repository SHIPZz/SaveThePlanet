using System;
using CodeBase.Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageAnswerCellView : MonoBehaviour, IDropHandler
    {
        public GarbageType GarbageType;
        public Image Icon;

        [Inject] private GarbageMinigameService _garbageMinigameService;

        private void Awake() => Icon.enabled = false;

        public void Init(GarbageType garbageType, Sprite icon)
        {
            GarbageType = garbageType;
            Icon.sprite = icon;
        }

        public void SetIcon(Sprite icon)
        {
            Icon.sprite = icon;
            Icon.enabled = true;
        }

        public void OnDrop(PointerEventData eventData)
        {
            var droppedItem = eventData.pointerDrag.gameObject.GetComponent<GarbageInfoPopupView>();

            if (!_garbageMinigameService.TryNotifyGarbageAnswered(droppedItem, this))
                return;

            Icon.sprite = eventData.pointerDrag.gameObject.GetComponent<GarbageInfoPopupView>().Icon.sprite;
            Icon.enabled = true;
        }
    }
}