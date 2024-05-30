using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class ButtonGarbageOptionView : MonoBehaviour
    {
        public GarbageInfoPopupView GarbageInfoPopupView;

        private Button _button;
        [Inject] private GarbageMinigameService _garbageMinigameService;


        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AsObservable()
                .Subscribe(_ => _garbageMinigameService.TryNotifyGarbageAnswered(GarbageInfoPopupView)).AddTo(this);
        }
    }
}