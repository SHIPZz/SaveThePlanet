using System;
using UnityEngine;

namespace CodeBase.UI.FrameMessage
{
    public class PlaySoundOnMessage : MonoBehaviour
    {
        [SerializeField] private AudioSource _sound;
        [SerializeField] private FrameMessageView _frameMessageView;

        private void OnEnable()
        {
            _frameMessageView.Shown += _sound.Play;
        }

        private void OnDisable()
        {
            _frameMessageView.Shown -= _sound.Play;
        }
    }
}