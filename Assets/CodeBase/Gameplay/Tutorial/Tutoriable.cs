using System;
using UnityEngine;

namespace CodeBase.Gameplay.Tutorial
{
    public class Tutoriable : MonoBehaviour
    {
        public event Action Locked;
        public event Action UnLocked;
        
        public void Lock() => 
            Locked?.Invoke();

        public void UnLock() => 
            UnLocked?.Invoke();
    }
}