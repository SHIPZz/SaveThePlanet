using System.Collections.Generic;
using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.ScriptableObjects.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialSO", menuName = "Gameplay/Data/Tutorial")]
    public class TutorialSO : ScriptableObject
    {
        public List<TutorialType> TutorialQueue;

        public IReadOnlyList<TutorialType> ReadonlyTutorialQueue => TutorialQueue;
    }
}