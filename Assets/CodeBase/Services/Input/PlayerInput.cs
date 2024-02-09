using UnityEngine;
using Zenject;

namespace CodeBase.Services.Input
{
    public class PlayerInput : ITickable
    {
        private IInputService _inputService;

        public PlayerInput(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Tick()
        {
        }
    }
}