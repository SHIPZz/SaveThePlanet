using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.ScriptableObjects.WarningItems
{
    [CreateAssetMenu(fileName = "WarningItemSO", menuName = "Gameplay/Data/WarningItemSO")]
    public class WarningItemSO : ScriptableObject
    {
        public WarningItemType WarningItemType;
        public string Description;
        public Sprite Icon;
    }
}