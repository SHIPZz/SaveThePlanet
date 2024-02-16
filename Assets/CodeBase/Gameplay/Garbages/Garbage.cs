using System;
using CodeBase.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class Garbage : MonoBehaviour
    {
        public GarbageType GarbageType;

        public event Action<Garbage> Destroyed;

        [Button]
        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}