using UnityEngine;

namespace CodeBase.Gameplay.Quest
{
    [CreateAssetMenu(fileName = nameof(QuestAnswer), menuName = "Gameplay/Data/Quest answer data")]
    public class QuestAnswer : ScriptableObject
    {
        public string Value;
    }
}