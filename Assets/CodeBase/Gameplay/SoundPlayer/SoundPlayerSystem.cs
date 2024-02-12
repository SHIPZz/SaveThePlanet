using UnityEngine;

namespace CodeBase.Gameplay.SoundPlayer
{
    public class SoundPlayerSystem : MonoBehaviour
    {
        public AudioSource ActiveSound;
        public AudioSource InactiveSound;

        public void PlayActiveSound() => ActiveSound.Play();

        public void PlayInactiveSound() => InactiveSound.Play();
    }
}