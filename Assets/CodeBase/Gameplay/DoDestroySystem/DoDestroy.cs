using CodeBase.Gameplay.CleanUpSystem;
using UnityEngine;

namespace CodeBase.Gameplay.DoDestroySystem
{
    public class DoDestroy : MonoBehaviour
    {
        private ICleanUp[] _cleanUps;

        private void Awake() => 
            _cleanUps = GetComponents<ICleanUp>();

        private void OnEnable()
        {
            foreach (ICleanUp cleanUp in _cleanUps)
            {
                cleanUp.CleanedUp += Do;
            }
        }

        private void Do()
        {
            foreach (ICleanUp targetCleanUp in _cleanUps)
            {
                targetCleanUp.CleanUp();
            }
            
            Destroy(gameObject);
        }
    }
}