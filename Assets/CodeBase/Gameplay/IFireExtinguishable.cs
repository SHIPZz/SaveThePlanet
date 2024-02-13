using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public interface IFireExtinguishable
    {
        Transform Anchor { get; }
        void PutOut();
        void MoveTo(Vector3 target,Action onComplete = null);
        void RotateTo(Vector3 target, Action onComplete = null);
        event Action<IFireExtinguishable> Done;
    }
}