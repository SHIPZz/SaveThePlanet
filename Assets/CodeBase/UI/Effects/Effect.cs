using CodeBase.Enums;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.UI.Effects
{
    public class Effect : MonoBehaviour
    {
        public EffectType EffectType;
        public ParticleSystem Particle;

        public void SetAutoDestroy(float destroyTime)
        {
            ParticleSystem.MainModule mainModule = Particle.main;
            mainModule.stopAction = ParticleSystemStopAction.Destroy;
            DOTween.Sequence().AppendInterval(destroyTime).OnComplete(Particle.Stop);
        }
    }
}