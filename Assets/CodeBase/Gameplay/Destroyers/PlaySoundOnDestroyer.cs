using System;
using CodeBase.Gameplay.CleanUpSystem;
using UnityEngine;

namespace CodeBase.Gameplay.Destroyers
{
    public class PlaySoundOnDestroyer : MonoBehaviour,ICleanUp
    {
        public AudioSource AudioSource;

        public void CleanUp()
        {
            AudioSource.Play();
        }
    }
}