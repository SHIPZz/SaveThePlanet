using System;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerHandContainer
    {
        public ITakeable CurrentObject;

        public event Action Cleared;
        
        public void Clear()
        {
            CurrentObject = null;
            Cleared?.Invoke();
        }
    }
}