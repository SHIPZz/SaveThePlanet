using CodeBase.Enums;
using TMPro;
using UnityEngine;

namespace CodeBase.ScriptableObjects.WarningItems
{
    [CreateAssetMenu(fileName = "WarningItemSO", menuName = "Gameplay/Data/WarningItemSO")]
    public class WarningItemSO : ScriptableObject
    {
        public WarningItemType WarningItemType;
        public TMP_Text DescriptionText;
        public Sprite Icon;
    }
}