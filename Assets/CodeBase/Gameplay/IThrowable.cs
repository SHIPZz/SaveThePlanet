using UnityEngine;

namespace CodeBase.Gameplay
{
    public interface IThrowable
    {
        Transform Transform { get; }
        void SetRotation();
    }
}