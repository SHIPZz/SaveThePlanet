using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.Quest
{
    public class QuestService
    {
        private readonly List<QuestSO> _quests;
        private List<string> _gotAnswers = new();

        private int _questIndex = -1;
        private int _questionIndex;
        private QuestSO _currentQuest;
        private Question _currentQuestion;

        public event Action AllQuestFinished;
        public event Action CorrectAnswerSelected;

        public QuestService(QuestStaticDataService questStaticDataService)
        {
            _quests = questStaticDataService.Quests.ToList();
        }

        public string GetRandomAnswer(Question question)
        {
            foreach (KeyValuePair<string, bool> keyValuePair in question.QuestionAnswers.Where(x =>
                         !_gotAnswers.Contains(x.Key)))
            {
                _gotAnswers.Add(keyValuePair.Key);
                return keyValuePair.Key;
            }

            throw new ArgumentException("NO ANSWERS");
        }

        public QuestSO GetRandomQuest()
        {
            var randomQuest = _quests[Random.Range(0, _quests.Count)];
            return randomQuest;
        }

        public Question GetQuestion()
        {
            Question question = _currentQuest.Questions.Find(x => x != _currentQuestion);

            if (question == null)
            {
                if (_questIndex >= _quests.Count)
                {
                    AllQuestFinished?.Invoke();
                    return null;
                }
                
                _questIndex = Mathf.Clamp(_questIndex + 1, 0, _quests.Count);
                _currentQuest = _quests[_questIndex];
            }

            _currentQuestion = question;


            return _currentQuestion;
        }

        public Question GetRandomQuestion(QuestSO quest)
        {
            _currentQuestion = quest.Questions[Random.Range(0, quest.Questions.Count)];
            _currentQuest = quest;
            _questIndex = Mathf.Clamp(_questIndex + 1, 0, _quests.Count);
            return _currentQuestion;
        }

        public void NotifyCorrectAnswerSelected()
        {
            CorrectAnswerSelected?.Invoke();
        }

        public bool IsAnswerCorrect(string answer)
        {
            return _currentQuestion.QuestionAnswers[answer];
        }
    }
}