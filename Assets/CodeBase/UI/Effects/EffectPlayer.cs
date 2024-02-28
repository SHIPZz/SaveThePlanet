using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Effects
{
    public class EffectPlayer : MonoBehaviour
    {
        public List<ParticleSystem> Effects;

        public void PlayEffects()
        {
            Effects.ForEach(x => x.Play(true));
        }

        public void StopEffects()
        {
            Effects.ForEach(x => x.Stop(true));
        }
    }
}