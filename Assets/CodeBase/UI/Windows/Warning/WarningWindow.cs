using CodeBase.Animations;
using CodeBase.Enums;
using CodeBase.Gameplay.WarningItems;
using CodeBase.ScriptableObjects.WarningItems;
using CodeBase.Services.StaticData;
using DG.Tweening;
using TMPro;
using UnityEngine;
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
            CanvasAnimator.FadeInCanvas(() =>
                DOTween
                    .Sequence()
                    .AppendInterval(ButtonScaleAnimDelay)
                    .OnComplete(() => ButtonScaleAnim.ToScale()));
        }

        public void Init(WarningItem warningItem)
        {
            WarningItemSO data = _uiStaticDataService.Get(warningItem.WarningItemType);
            WarningItemIcon.sprite = data.Icon;
            DescriptionText.text = data.Description;
        }
    }
}