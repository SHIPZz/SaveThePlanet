using System;

namespace CodeBase.Gameplay.Tutorial
{
    public interface ITutoriable
    {
        event Action Completed;
        void Init();
    }
}