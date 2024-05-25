using System;
using UniRx;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    public class GarbageMinigameService
    {
        private GarbageMinigameFactory _garbageMinigameFactory;
        private Transform _garbageOptionParent;
        private Transform _garbageAnswerParent;

        private readonly Subject<Unit> _minigameFinished = new();

        public IObservable<Unit> MinigameFinished => _minigameFinished;

        public GarbageMinigameService(GarbageMinigameFactory garbageMinigameFactory)
        {
            _garbageMinigameFactory = garbageMinigameFactory;
        }

        public void Init(Transform garbageOptionParent, Transform garbageAnswerParent)
        {
            _garbageMinigameFactory.Init();
            _garbageAnswerParent = garbageAnswerParent;
            _garbageOptionParent = garbageOptionParent;
            _garbageMinigameFactory.CreateAnswerCellView(garbageAnswerParent, Vector3.zero);
            _garbageMinigameFactory.CreateGarbageOptionViews(garbageOptionParent, Vector3.zero);
        }

        public bool TryGoNext()
        {
            var garbageOptionViews = _garbageMinigameFactory.CreateGarbageOptionViews(_garbageOptionParent, Vector3.zero);

            var garbageAnswer = _garbageMinigameFactory.CreateAnswerCellView(_garbageAnswerParent, Vector3.zero);

            if (garbageAnswer == null || garbageOptionViews == null)
            {
                _minigameFinished?.OnNext(Unit.Default);
                return false;
            }

            return true;
        }

        public void CleanUp()
        {
            _garbageMinigameFactory.CleanUp();
        }

        public void NotifyGarbageViewCollision(Collider other, GarbageInfoPopupView garbageInfoPopupView)
        {
            if (!other.gameObject.TryGetComponent(out GarbageAnswerCellView garbageAnswerCellView))
                return;

            Debug.Log($"{garbageAnswerCellView.GarbageType} - {garbageInfoPopupView.GarbageType}");
            if (garbageAnswerCellView.GarbageType == garbageInfoPopupView.GarbageType)
            {
                garbageAnswerCellView.SetIcon(garbageInfoPopupView.Icon.sprite);
                garbageInfoPopupView.Parent.gameObject.SetActive(false);
            }
        }
    }
}