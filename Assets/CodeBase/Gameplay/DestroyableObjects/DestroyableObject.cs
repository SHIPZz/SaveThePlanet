using System;
using CodeBase.Enums;
using CodeBase.Gameplay.CleanUpSystem;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class DestroyableObject : MonoBehaviour, ICleanUp
    {
        public DestroyableTypeId DestroyableTypeId;
        public event Action Destroyed;

        public event Action CleanedUp;

        public void Destroy()
        {
            CleanedUp?.Invoke();
        }

        public void CleanUp()
        {
            Destroyed?.Invoke();
        }
    }
}