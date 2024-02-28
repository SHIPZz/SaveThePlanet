using CodeBase.Gameplay.CleanUpSystem;
using UnityEngine;

namespace CodeBase.Gameplay.DoDestroySystem
{
    public class DoDestroy : MonoBehaviour
    {
        public float DestroyDelay;
        
        private ICleanUp[] _cleanUps;

        private void Awake() => 
            _cleanUps = GetComponents<ICleanUp>();

        public void Do()
        {
            foreach (ICleanUp targetCleanUp in _cleanUps)
            {
                targetCleanUp.CleanUp();
            }

            Destroy(gameObject,DestroyDelay);
        }
    }
}