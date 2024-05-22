using CodeBase.Enums;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialCheat : MonoBehaviour
    {
        private TutorialService _tutorialService;

        [Inject]
        private void Construct(TutorialService tutorialService)
        {
            _tutorialService = tutorialService;
        }

        [Button]
        public void SetFinished(TutorialType tutorialType)
        {
            _tutorialService.TryExecute(tutorialType);
        }
    }
}