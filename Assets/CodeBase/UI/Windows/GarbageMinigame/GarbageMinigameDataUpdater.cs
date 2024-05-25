using System.Collections.Generic;
using CodeBase.Enums;
using UnityEditor;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    //chatgpt
    public class GarbageMinigameDataUpdater
    {
        [MenuItem("GarbageMinigame/Update Garbage Option Infos")]
        public static void UpdateGarbageOptionInfos()
        {
            GarbageMiniGameSO garbageMiniGameSO =
                AssetDatabase.LoadAssetAtPath<GarbageMiniGameSO>("Assets/Resources/Data/Minigame/GarbageMiniGameSO.asset");
            if (garbageMiniGameSO == null)
            {
                Debug.LogError("GarbageMiniGameSO.asset not found in Assets/Resources/Data/");
                return;
            }

            List<GarbageOptionInfo> newGarbageOptionInfos = new List<GarbageOptionInfo>
            {
                CreateGarbageOptionInfo("Пластиковый пакет", GarbageType.Plastic,
                    "Пластиковый пакет разлагается сотни лет и может стать причиной гибели животных.", 3),
                CreateGarbageOptionInfo("Пластиковая крышка", GarbageType.Plastic,
                    "Маленькие пластиковые предметы могут быть проглочены животными, вызывая удушье.", 2),
                CreateGarbageOptionInfo("Консервная банка", GarbageType.Metal,
                    "Консервные банки могут вызвать порезы и загрязнение, если выброшены неправильно.", 3),
                CreateGarbageOptionInfo("Жестяная банка", GarbageType.Metal,
                    "Жестяные банки могут загрязнять окружающую среду и быть опасными для животных.", 2),
                CreateGarbageOptionInfo("Газета", GarbageType.Paper,
                    "Хотя газета легко перерабатывается, если её не переработать, она может способствовать вырубке лесов и накоплению отходов.",
                    1),
                CreateGarbageOptionInfo("Картонная коробка", GarbageType.Paper,
                    "Картон легко перерабатывается, но если выброшен, он разлагается и может вызвать загромождение.",
                    1),
                CreateGarbageOptionInfo("Бумажный стаканчик", GarbageType.Paper,
                    "Бумажные стаканчики часто содержат пластиковое покрытие, что затрудняет их переработку.", 2),
                CreateGarbageOptionInfo("Химическая бочка", GarbageType.Industrial,
                    "Химическая бочка содержит опасные химикаты, которые могут вызвать серьёзное загрязнение почвы и воды, а также быть опасными для здоровья человека.",
                    5),
                CreateGarbageOptionInfo("Батарейка", GarbageType.Industrial,
                    "Батарейки содержат тяжёлые металлы и токсичные вещества, которые могут загрязнять почву и воду.",
                    4),
                CreateGarbageOptionInfo("Лампа накаливания", GarbageType.Industrial,
                    "Лампы содержат ртуть и другие опасные вещества, которые могут быть опасны для здоровья.", 4),
                CreateGarbageOptionInfo("Смешанные отходы", GarbageType.Generic,
                    "Смешанные отходы могут содержать различные виды опасных материалов, которые трудно перерабатывать и которые могут представлять угрозу для окружающей среды и здоровья.",
                    4),
                CreateGarbageOptionInfo("Пищевые отходы", GarbageType.Generic,
                    "Пищевые отходы разлагаются и могут вызывать неприятные запахи и привлекать вредителей.", 3),
                CreateGarbageOptionInfo("Стекло", GarbageType.Generic,
                    "Стекло может быть переработано, но если выброшено, оно может стать причиной порезов и ранений.",
                    2),
                CreateGarbageOptionInfo("Текстиль", GarbageType.Generic,
                    "Текстильные отходы могут разлагаться долгое время, вызывая загрязнение.", 3),
                CreateGarbageOptionInfo("Электронные отходы", GarbageType.Generic,
                    "Электронные устройства содержат опасные вещества и должны утилизироваться правильно.", 5),
                CreateGarbageOptionInfo("Одноразовая посуда", GarbageType.Plastic,
                    "Одноразовая посуда из пластика разлагается долго и может загрязнять окружающую среду.", 3),
                CreateGarbageOptionInfo("Стеклянная бутылка", GarbageType.Generic,
                    "Стеклянные бутылки могут быть переработаны, но если выброшены, они могут стать причиной травм.",
                    2),
                CreateGarbageOptionInfo("Фармацевтические отходы", GarbageType.Industrial,
                    "Фармацевтические отходы могут содержать опасные химикаты, которые загрязняют окружающую среду и опасны для здоровья.",
                    5)

            };
            
            garbageMiniGameSO.GarbageMinigameData.GarbageOptionInfos.AddRange(newGarbageOptionInfos);

            EditorUtility.SetDirty(garbageMiniGameSO);
            AssetDatabase.SaveAssets();
        }

        private static GarbageOptionInfo CreateGarbageOptionInfo(string name, GarbageType garbageType, string description, int dangerRate)
        {
            GarbageOptionInfo info = new GarbageOptionInfo
            {
                Name = name,
                GarbageType = garbageType,
                Description = description,
                DangerRate = dangerRate,
                Icon = null 
            };

            return info;
        }
    }
}