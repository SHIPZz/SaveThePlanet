using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    [CreateAssetMenu(fileName = nameof(GarbageMiniGameSO), menuName = "Gameplay/Data/GarbageMiniGameSO")]
    public class GarbageMiniGameSO : SerializedScriptableObject
    {
        public GarbageMinigameData GarbageMinigameData = new();
        public GarbageOptionView GarbageOptionViewPrefab;
        public GarbageAnswerCellView GarbageAnswerCellViewPrefab;
    }
}