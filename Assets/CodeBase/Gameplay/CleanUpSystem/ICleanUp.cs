using System;

namespace CodeBase.Gameplay.CleanUpSystem
{
    public interface ICleanUp
    {
        event Action CleanedUp;
        void CleanUp();
    }
}