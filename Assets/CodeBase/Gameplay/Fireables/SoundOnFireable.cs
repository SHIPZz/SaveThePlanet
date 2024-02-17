using CodeBase.Gameplay.SoundPlayer;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    [RequireComponent(typeof(SoundPlayerSystem))]
    [RequireComponent(typeof(Fireable))]
    public class SoundOnFireable : MonoBehaviour
    {
        private Fireable _fireable;
        private SoundPlayerSystem _soundPlayerSystem;

        private void Awake()
        {
            _fireable = GetComponent<Fireable>();
            _soundPlayerSystem = GetComponent<SoundPlayerSystem>();
        }

        private void OnEnable()
        {
            _fireable.OnPutOut += Play;
        }

        private void OnDisable()
        {
            _fireable.OnPutOut -= Play;
        }

        private void Play()
        {
            _soundPlayerSystem.PlayActiveSound();
        }
    }
}