using CodeBase.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageInfoPopupView : MonoBehaviour
    {
        public Transform Parent;
        public GarbageType GarbageType;
        public Image Icon;
        public TMP_Text NameText;
        public TMP_Text DescriptionText;

        public void Init(GarbageType garbageType, Sprite icon, TMP_Text nameText, TMP_Text descriptionText)
        {
            GarbageType = garbageType;
            Icon.sprite = icon;
            NameText = nameText;
            DescriptionText = descriptionText;
        }
    }
}