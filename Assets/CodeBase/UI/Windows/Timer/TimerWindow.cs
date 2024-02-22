using TMPro;
using UnityEngine;

namespace CodeBase.UI.Windows.Timer
{
    public class TimerWindow : WindowBase
    {
        public TMP_Text TimerText;
        private Gameplay.TimerSystem.Timer _timer;

        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
        }

        public void SetTimer(Gameplay.TimerSystem.Timer timer)
        {
            _timer = timer;
        }

        private void Update()
        {
            float timeInSeconds = _timer.Value;

            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);

            TimerText.text = minutes > 0 ? $"{minutes}m:{seconds:00}s" : seconds.ToString();
        }
    }
}