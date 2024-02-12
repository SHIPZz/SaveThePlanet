using System;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public interface ITakeable
    {
        Transform Transform { get; }
        event Action<ITakeable> Dropped;
    }
}