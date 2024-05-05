using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using UnityEngine;

namespace CodeBase.Gameplay.Quest
{
    public class QuestStaticDataService
    {
        private readonly List<QuestSO> _quests;

        public IReadOnlyList<QuestSO> Quests => _quests;

        public QuestStaticDataService()
        {
            _quests = Resources.LoadAll<QuestSO>(AssetPath.QuestSO)
                .ToList();
        }
        
    }
}