using UnityEngine;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        public PlayerInputActions PlayerInputActions { get; private set; }

        public InputService()
        {
            PlayerInputActions = new();
            PlayerInputActions.Enable();
        }

        public Vector3 ReadMovementValue() => PlayerInputActions.Player.MovementAction.ReadValue<Vector2>();
    }

    public interface IInputService
    {
        Vector3 ReadMovementValue();
    }
}