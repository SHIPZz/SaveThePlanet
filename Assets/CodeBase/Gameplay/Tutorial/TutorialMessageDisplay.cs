using System;
using System.Collections.Generic;
using CodeBase.UI.FrameMessage;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialMessageDisplay : MonoBehaviour
    {
        public List<FrameMessageView> FrameMessageViews;

        private int _id = -1;

        public void TryShowNextMessage(Action onAllShown = null, Action onMessageShown = null)
        {
            _id++;

            if (!AreMoreMessagesAvailable())
            {
                onAllShown?.Invoke();
                return;
            }
            
            if (LastMessageIsNotNull())
            {
                FrameMessageViews[_id - 1].Hide( () =>SetAndShow(onMessageShown));
                return;
            }
            
            SetAndShow(onMessageShown);
        }

        private void SetAndShow(Action onMessageShown = null) => FrameMessageViews[_id].Show(onMessageShown);

        private bool LastMessageIsNotNull () => _id - 1 >= 0 && FrameMessageViews[_id-1] != null;
        
        private bool AreMoreMessagesAvailable() =>  _id < FrameMessageViews.Count;
    }
}