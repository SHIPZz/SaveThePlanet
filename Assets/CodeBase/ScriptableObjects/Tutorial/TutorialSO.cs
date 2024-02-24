using CodeBase.Enums;
using TMPro;
using UnityEngine;

namespace CodeBase.ScriptableObjects.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialSO", menuName = "Gameplay/Data/Tutorial")]
    public class TutorialSO : ScriptableObject
    {
        public TutorialType TutorialType;
        public TextMeshProUGUI Text;
    }
}