using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Gameplay.Quest
{
    public enum AnswerButtonType
    {
        Successful,
        Error,
    }

    public class ButtonAnswerView : SerializedMonoBehaviour
    {
        [OdinSerialize] public Dictionary<AnswerButtonType, Sprite> AnswerIcons;

        public List<Sprite> DefaultIcons;


        public TMP_Text ValueText;

        public string TargetAnswer { get; set; }

        private Button _button;
        private QuestService _questService;
        private Sprite _initialIcon;
        private bool _canPress = true;

        [Inject]
        private void Construct(QuestService questService)
        {
            _questService = questService;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.image.sprite = DefaultIcons[Random.Range(0, DefaultIcons.Count)];
            _initialIcon = _button.image.sprite;
        }

        public void Init(string targetAnswer)
        {
            TargetAnswer = targetAnswer;
            ValueText.text = TargetAnswer;
        }

        private void OnEnable() =>
            _button.onClick.AddListener(OnAnswerClicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnAnswerClicked);

        private void OnAnswerClicked()
        {
            if (!_canPress)
                return;

            _canPress = false;

            if (_questService.IsAnswerCorrect(TargetAnswer))
            {
                SetIcon(AnswerButtonType.Successful);
                _questService.NotifyCorrectAnswerSelected();
                return;
            }

            SetIcon(AnswerButtonType.Error);
        }

        public void SetIcon(AnswerButtonType answerButtonType, bool resetWithDelay = true)
        {
            var targetIcon = AnswerIcons[answerButtonType];
            _button.image.sprite = targetIcon;

            if (resetWithDelay)
            {
                DOTween.Sequence().AppendInterval(1f).OnComplete(() =>
                {
                    _button.image.sprite = _initialIcon;
                    _canPress = true;
                }).SetUpdate(true);
            }
        }
    }
}