using System;
using System.Collections.Generic;
using CodeBase.UI.FrameMessage;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class TutorialMessageController : MonoBehaviour
    {
        public List<FrameMessageView> FrameMessageViews;

        private FrameMessageView _lastMessageView;
        private int _id = -1;

        public void ShowFirstMessage()
        {
            _id++;
            _lastMessageView = FrameMessageViews[_id];
            _lastMessageView.Show();
        }

        public void TryShowNextMessage(Action onAllShown = null, Action onHasNotNextMessages = null,
            Action onMessageShown = null)
        {
            _id++;

            if (!AreMoreMessagesAvailable())
                onHasNotNextMessages?.Invoke();
            
            if (_id >= FrameMessageViews.Count)
            {
                onAllShown?.Invoke();
                return;
            }

            if (_lastMessageView != null)
            {
                _lastMessageView?.Hide(() =>
                {
                    GetAndShow(onMessageShown);
                });
                
                return;
            }
            
            GetAndShow(onMessageShown);
        }

        private void GetAndShow(Action onMessageShown = null)
        {
            _lastMessageView = FrameMessageViews[_id];
            _lastMessageView.Show(onMessageShown);
        }

        private bool AreMoreMessagesAvailable()
        {
            var tempId = _id;

            tempId++;

            return tempId < FrameMessageViews.Count;
        }
    }
}