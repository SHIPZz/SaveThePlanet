using CodeBase.Enums;
using CodeBase.Services.Settings;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.ToggleSystem
{
    public class ToggleAnimSwitcher : MonoBehaviour
    {
        private UnityEngine.UI.Toggle _toggle;
        private ToggleAnimation _toggleAnimation;

        private void Awake()
        {
            _toggle = GetComponent<UnityEngine.UI.Toggle>();
            _toggleAnimation = GetComponent<ToggleAnimation>();
        }

        private void Start() => 
            _toggleAnimation.Initialize(_toggle.isOn);

        private void OnEnable() =>
            _toggle.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() =>
            _toggle.onValueChanged.RemoveListener(OnValueChanged);

        private void OnValueChanged(bool isOn) => 
            _toggleAnimation.MoveHandleWithAnim(isOn);
    }
}