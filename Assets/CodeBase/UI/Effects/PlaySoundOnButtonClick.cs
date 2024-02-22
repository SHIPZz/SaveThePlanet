using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Effects
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    public class PlaySoundOnButtonClick : MonoBehaviour
    {
        private AudioSource _audioSource;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable() => 
            _button.onClick.AddListener(Play);

        private void OnDisable() => 
            _button.onClick.RemoveListener(Play);

        private void Play() => 
            _audioSource.Play();
    }
}