using System;
using CodeBase.Services.Factories;
using CodeBase.UI.Windows.Timer;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.TimerSystem
{
    [RequireComponent(typeof(Timer))]
    public class CreateTimerWindowOnITimer : MonoBehaviour
    {
        public Vector3 Offset;

        private Timer _timer;
        private UIFactory _uiFactory;
        private TimerWindow _timerWindow;

        [Inject]
        private void Construct(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _timer = GetComponent<Timer>();
        }

        private void OnEnable()
        {
            _timer.Started += CreateAndOpen;
        }

        private void OnDisable()
        {
            if (_timerWindow != null)
                _timer.Stopped -= _timerWindow.Close;
            
            _timer.Started -= CreateAndOpen;
        }

        private void CreateAndOpen()
        {
            _timerWindow = _uiFactory.CreateWindow<TimerWindow>();
            _timerWindow.transform.position = transform.position;
            _timerWindow.transform.position += Offset;
            _timerWindow.SetTimer(_timer);
            _timerWindow.Open();
            _timer.Stopped += _timerWindow.Close;
        }
    }
}