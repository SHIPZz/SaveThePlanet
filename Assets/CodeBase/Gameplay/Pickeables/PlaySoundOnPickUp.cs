using System;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class PlaySoundOnPickUp : MonoBehaviour
    {
        public AudioSource Audio;

        private Pickeable _pickeable;

        private void Awake() => 
            _pickeable = GetComponent<Pickeable>();

        private void OnEnable() => 
            _pickeable.OnPickedUp += Play;

        private void OnDisable() => 
            _pickeable.OnPickedUp -= Play;

        private void Play(Transform obj)
        {
            Audio.Play();
        }
    }
}