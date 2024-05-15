using System;
using CodeBase.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageAnswerCellView : MonoBehaviour
    {
        public GarbageType GarbageType;
        public Image Icon;

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
    }
}