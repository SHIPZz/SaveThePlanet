using System;
using CodeBase.Enums;
using CodeBase.Services.Settings;
using CodeBase.UI.ToggleSystem;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace CodeBase.UI.Sound
{
    public class SoundHandler : MonoBehaviour
    {
        private const float DisableSoundValue = -80f;
        [SerializeField] private UnityEngine.UI.Toggle _toggle;
        [SerializeField] private MixerTypeId _mixerTypeId;
        [SerializeField] private ToggleAnimation _toggleAnimation;

        private SettingService _settingsService;
        private AudioMixerGroup _audioMixerGroup;

        [Inject]
        private void Construct(SettingService settingsService)
        {
            _settingsService = settingsService;
        }

        private void Start()
        {
            _audioMixerGroup = _settingsService.Get(Enum.GetName(typeof(MixerTypeId), _mixerTypeId));
            var isOn = _settingsService.GetTargetSoundValue(_mixerTypeId);
            _toggle.isOn = isOn;
            _toggleAnimation.Initialize(isOn);
            ChangeVolume(_toggle.isOn);
        }

        private void OnEnable() =>
            _toggle.onValueChanged.AddListener(ChangeVolume);

        private void OnDisable() =>
            _toggle.onValueChanged.RemoveListener(ChangeVolume);

        private void OnDestroy() => 
            _settingsService.SetSoundSettings(_toggle.isOn, _mixerTypeId);

        private void ChangeVolume(bool isOn)
        {
            if (!isOn)
            {
                SetValue(DisableSoundValue);
            }
        }

        private void SetValue(float value)
        {
            _audioMixerGroup.audioMixer.SetFloat(Enum.GetName(typeof(MixerTypeId), _mixerTypeId), value);
            _settingsService.SetSoundSettings(_toggle.isOn, _mixerTypeId);
        }
    }
}