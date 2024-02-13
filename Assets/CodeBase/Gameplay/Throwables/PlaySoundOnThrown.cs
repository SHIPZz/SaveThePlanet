using System;
using UnityEngine;

namespace CodeBase.Gameplay.Throwables
{
    public class PlaySoundOnThrown : MonoBehaviour
    {
        public AudioSource AudioSource;

        private Throwable _throwable;

        private void Awake() => 
            _throwable = GetComponent<Throwable>();

        private void OnEnable() => 
            _throwable.Thrown += Play;

        private void OnDisable() => 
            _throwable.Thrown -= Play;

        private void Play() => 
            AudioSource.Play();
    }
}