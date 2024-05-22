using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using CodeBase.Gameplay.Tutorial;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace CodeBase.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/TutorialCompletedSO", fileName = nameof(TutorialCompletedSO))]
    public class TutorialCompletedSO : SerializedScriptableObject
    {
        [OdinSerialize] public Dictionary<TutorialType, bool> _completedTutorials = new();

        [Button]
        public void CompleteTutorial(TutorialType tutorialType)
        {
            var targetTutorial = FindObjectsOfType<AbstractTutorialStep>().FirstOrDefault(x =>x.TutorialType == tutorialType);
            targetTutorial.OnFinished();
            
        }
    }
    
    [CreateAssetMenu(menuName = "Data/TutorialInstallerCompletedSO", fileName = nameof(TutorialInstallerCompletedSO))]
    public class TutorialInstallerCompletedSO : ScriptableObjectInstaller
    {
        public TutorialCompletedSO TutorialCompletedSo;
        
        public override void InstallBindings()
        {
            Container.BindInstance(TutorialCompletedSo);
        }
    }
}