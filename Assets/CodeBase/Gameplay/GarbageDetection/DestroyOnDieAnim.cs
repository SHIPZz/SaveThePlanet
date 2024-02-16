using UnityEngine;

namespace CodeBase.Gameplay.GarbageDetection
{
    public class DestroyOnDieAnim : MonoBehaviour
    {
        public void OnAnimationEnded()
        {
            Destroy(gameObject);
        }
    }
}