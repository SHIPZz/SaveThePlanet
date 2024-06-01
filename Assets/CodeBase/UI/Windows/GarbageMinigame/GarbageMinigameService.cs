using System;
using CodeBase.Enums;
using UniRx;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageMinigameService
    {
        private const int MaxQuestionCount = 20;
        private GarbageMinigameFactory _garbageMinigameFactory;
        private Transform _garbageOptionParent;
        private Transform _garbageAnswerParent;
        private int _questionCount;

        private readonly Subject<Unit> _minigameFinished = new();
        private UnityEngine.Canvas _canvas;

        public IObservable<Unit> MinigameFinished => _minigameFinished;

        public GarbageMinigameService(GarbageMinigameFactory garbageMinigameFactory)
        {
            _garbageMinigameFactory = garbageMinigameFactory;
        }

        public void Init(Transform garbageOptionParent, Transform garbageAnswerParent, UnityEngine.Canvas canvas)
        {
            _canvas = canvas;
            _garbageMinigameFactory.Init();
            _garbageAnswerParent = garbageAnswerParent;
            _garbageOptionParent = garbageOptionParent;
            _garbageMinigameFactory.CreateAnswerCellView(garbageAnswerParent, Vector3.zero);
            _garbageMinigameFactory.CreateGarbageOptionViews(garbageOptionParent, Vector3.zero,_canvas);
        }

        public bool TryGoNext()
        {
            if (_questionCount + 1 >= MaxQuestionCount)
            {
                _minigameFinished?.OnNext(Unit.Default);
                return false;
            }

            _garbageMinigameFactory.CleanUpCreatedViews();
            var garbageAnswer = _garbageMinigameFactory.CreateAnswerCellView(_garbageAnswerParent, Vector3.zero);
            
            var garbageOptionViews = _garbageMinigameFactory.CreateGarbageOptionViews(_garbageOptionParent, Vector3.zero, _canvas);

            if (garbageAnswer == null || garbageOptionViews == null)
            {
                _minigameFinished?.OnNext(Unit.Default);
                return false;
            }

            _questionCount++;
            return true;
        }

        public void CleanUp()
        {
            _garbageMinigameFactory.CleanUp();
        }

        public bool TryNotifyGarbageAnswered(GarbageInfoPopupView garbageInfoPopupView)
        {
            if (_garbageMinigameFactory.LastAnswerCreated.GarbageType == garbageInfoPopupView.GarbageType)
            {
                _garbageMinigameFactory.AddCorrectView(garbageInfoPopupView.NameText.text);
                return TryGoNext();
            }

            return false;
        }
    }
}