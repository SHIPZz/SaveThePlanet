using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    [RequireComponent(typeof(EffectCreator))]
    [RequireComponent(typeof(Pickeable))]
    public class PickUpEffect : MonoBehaviour
    {
        private EffectCreator _effectCreator;
        private Pickeable _pickeable;
        private Effect _effect;

        private void Awake()
        {
            _effectCreator = GetComponent<EffectCreator>();
            _pickeable = GetComponent<Pickeable>();
        }

        private void OnEnable()
        {
            _effect = _effectCreator.CreateAndPlay(transform, Vector3.zero, true);
            _pickeable.OnPickedUp += DisableEffect;
            _pickeable.OnDropped += PlayEffect;
        }

        private void OnDisable()
        {
            _pickeable.OnPickedUp -= DisableEffect;
            _pickeable.OnDropped -= PlayEffect;
        }

        private void PlayEffect(Transform obj) => 
            _effect.Particle.Play();

        private void DisableEffect(Transform parent) => 
            _effect.Particle.Stop();
    }
}