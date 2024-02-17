using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Fireables
{
    public class Fireable : MonoBehaviour
    {
        public event Action OnFired;
        public event Action OnPutOut;

        public void Fire()
        {
            OnFired?.Invoke();
        }

        [Button]
        public void PutOut()
        {
            OnPutOut?.Invoke();
        }
    }
}