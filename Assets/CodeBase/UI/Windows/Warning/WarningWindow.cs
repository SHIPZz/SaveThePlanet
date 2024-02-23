using CodeBase.Animations;
using CodeBase.Enums;
using CodeBase.Gameplay.WarningItems;
using CodeBase.ScriptableObjects.WarningItems;
using CodeBase.Services.StaticData;
using CodeBase.UI.Windows.Hud;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Windows.Warning
{
    public class WarningWindow : WindowBase
    {
        public Image WarningItemIcon;
        public TMP_Text DescriptionText;
        public TransformScaleAnim ButtonScaleAnim;
        public float ButtonScaleAnimDelay = 3f;

        private UIStaticDataService _uiStaticDataService;

        [Inject]
        private void Construct(UIStaticDataService uiStaticDataService)
        {
            _uiStaticDataService = uiStaticDataService;
        }

        public override void Open()
        {
            WindowService.Close<HudWindow>();

            CanvasAnimator.FadeInCanvas(() =>
                DOTween.Sequence()
                    .AppendInterval(ButtonScaleAnimDelay)
                    .OnComplete(() => ButtonScaleAnim.ToScale())
                    .SetUpdate(true));
        }

        public override void Close()
        {
            WindowService.Open<HudWindow>();
            base.Close();
        }

        public void Init(WarningItemType warningItemType)
        {
            WarningItemSO data = _uiStaticDataService.Get(warningItemType);
            WarningItemIcon.sprite = data.Icon;
            DescriptionText = data.DescriptionText;
        }
    }
}