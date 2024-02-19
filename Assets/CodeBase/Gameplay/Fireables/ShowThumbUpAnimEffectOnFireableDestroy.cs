using CodeBase.Anims;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    public class ShowThumbUpAnimEffectOnFireableDestroy : MonoBehaviour
    {
        public ParticleSystem Effect;
        public TransformScaleAnim TransformScaleAnim;

        public DestroyAnimOnPutOut DestroyAnimOnPutOut;

        private void OnEnable() => 
            DestroyAnimOnPutOut.Destroyed += PlayPutOutEffects;

        private void OnDisable() => 
            DestroyAnimOnPutOut.Destroyed -= PlayPutOutEffects;

        private void PlayPutOutEffects()
        {
            transform.SetParent(null);
            TransformScaleAnim.ToScale();
            Effect.Play();
            
            float effectDuration = Effect.main.duration + Effect.main.startLifetime.constantMax;
            Destroy(gameObject, effectDuration);
        }
    }
}