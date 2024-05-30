using System;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OncePressButton : MonoBehaviour
{
    private readonly ReactiveCommand _onPressCommand = new();
        
    private Button _button;

    [ShowInInspector]
    [ReadOnly]
    private bool _wasPressed;
        
    public IObservable<Unit> OnPress => _onPressCommand;

    public void ResetPressState()
    {
        _wasPressed = false;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
            
        _button.onClick.AddListener(OnClick);
    }

    public void SetButtonInteractable(bool value)
    {
        if(_button != null)
            _button.interactable = value;
    }

    private void OnClick()
    {
        if (_wasPressed)
            return;

        _wasPressed = true;

        _onPressCommand.Execute();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }
}