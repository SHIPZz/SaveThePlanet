using System;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerHandContainer
    {
        private ITakeable _currentTakeable;

        public event Action Cleared;
        public event Action<ITakeable> Set;

        public ITakeable Takeable => _currentTakeable;

        public void TrySetCurrentObject(ITakeable takeable)
        {
            if(_currentTakeable != null)
                return;
            
            _currentTakeable = takeable;
            Set?.Invoke(_currentTakeable);
        }
        
        public void Clear()
        {
            _currentTakeable = null;
            Cleared?.Invoke();
        }
    }
}