using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace CodeBase.Gameplay.Quest {
    [CreateAssetMenu(fileName = nameof(QuestSO), menuName = "Gameplay/Data/Quest data")]
    public class QuestSO : SerializedScriptableObject
    {
        [OdinSerialize] public List<Question> Questions = new();
    }

    [Serializable]
    public class Question
    {
        public string Value;
        public Dictionary<string, bool> QuestionAnswers;
        public Sprite Icon;
    }
}