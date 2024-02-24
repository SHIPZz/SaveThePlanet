using System;
using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class Tutoriable : MonoBehaviour
    {
        public TutorialType TutorialType;

        public event Action Locked;
        public event Action UnLocked;
        
        public void Lock()
        {
            Locked?.Invoke();
        }

        public void UnLock()
        {
            UnLocked?.Invoke();
        }
    }
}