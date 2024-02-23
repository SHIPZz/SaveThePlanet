using CodeBase.Services.Camera;
using ECM.Components;
using ECM.Controllers;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class BlockMovementOnCameraPan : MonoBehaviour
    {
        private BaseCharacterController _baseCharacterController;
        private CameraService _cameraService;
        private CharacterMovement _characterMovement;

        [Inject]
        private void Construct(CameraService cameraService) => 
            _cameraService = cameraService;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _baseCharacterController = GetComponent<BaseCharacterController>();
        }

        private void OnEnable()
        {
            _cameraService.MovingStarted += Block;
            _cameraService.MovingFinished += UnBlock;
        }

        private void OnDisable()
        {
            _cameraService.MovingStarted -= Block;
            _cameraService.MovingFinished -= UnBlock;
        }

        private void UnBlock() => 
            IsEnabled(false);

        private void Block() => 
            IsEnabled(true);

        private void IsEnabled(bool isEnabled)
        {
            _baseCharacterController.IsBlocked = isEnabled;
            _characterMovement.Pause(isEnabled, false);
        }
    }
}