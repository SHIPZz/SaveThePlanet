using System.Collections.Generic;
using CodeBase.Services.Factories;
using CodeBase.UI.GoldPopup;
using CodeBase.UI.Windows;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Quest
{
    public class QuestWindow : WindowBase
    {
        public Transform Parent;
        public TMP_Text QuestionText;

        private QuestService _questService;
        private UIFactory _uiFactory;
        private List<ButtonAnswerView> _buttonAnswerViews = new();

        [Inject]
        private void Construct(QuestService questService, UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _questService = questService;
        }

        private void OnEnable()
        {
            _questService.CorrectAnswerSelected += OnCorrectAnswerSelected;
            _questService.AllAnswered += Close;
        }

        private void OnDisable()
        {
            _questService.CorrectAnswerSelected -= OnCorrectAnswerSelected;
            _questService.AllAnswered -= Close;
        }

        public override void Open()
        {
            CanvasAnimator.FadeInCanvas();
            QuestSO quest = _questService.GetRandomQuest();
            Question question = _questService.GetRandomQuestion(quest);
            ConfigureUI(question);
        }

        public override void Close()
        {
            WindowService.Open<GoldPopupWindow>();
            base.Close();
        }

        private void OnCorrectAnswerSelected()
        {
            ConfigureUI(_questService.GetQuestion());
        }

        private void ConfigureUI(Question question)
        {
            if(question == null)
                return;
            
            foreach (ButtonAnswerView buttonAnswerView in _buttonAnswerViews)
            {
                Destroy(buttonAnswerView.gameObject);
            }
            
            _buttonAnswerViews.Clear();

            QuestionText.text = question.Value;

            foreach (KeyValuePair<string, bool> keyValuePair in question.QuestionAnswers)
            {
                _buttonAnswerViews.Add(_uiFactory.CreateButtonAnswerView(Parent, keyValuePair.Key));
            }
        }
    }
}