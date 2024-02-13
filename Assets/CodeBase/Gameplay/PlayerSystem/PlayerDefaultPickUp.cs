using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerDefaultPickUp : PlayerPickUp
    {
        private PlayerHandContainer _playerHandContainer;

        [Inject]
        private void Construct(PlayerHandContainer playerHandContainer)
        {
            _playerHandContainer = playerHandContainer;
        }
        
        protected override void PickUp(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out ITakeable takeable))
                return;
            
            _playerHandContainer.TrySetCurrentObject(takeable);
        }
    }
}