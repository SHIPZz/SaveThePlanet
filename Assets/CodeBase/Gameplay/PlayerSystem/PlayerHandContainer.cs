using System;
using CodeBase.Gameplay.Pickeables;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerHandContainer
    {
        private Pickeable _currentPickeable;

        public event Action Cleared;
        public event Action<Pickeable> Set;

        public Pickeable Pickeable => _currentPickeable;

        public bool HasItem => _currentPickeable != null;

        public void TrySetCurrentObject(Pickeable takeable)
        {
            if(_currentPickeable != null)
                return;
            
            _currentPickeable = takeable;
            Set?.Invoke(_currentPickeable);
        }
        
        public void Clear()
        {
            _currentPickeable = null;
            Cleared?.Invoke();
        }
    }
}