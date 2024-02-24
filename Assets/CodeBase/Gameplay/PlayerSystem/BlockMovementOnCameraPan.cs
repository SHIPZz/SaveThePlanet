using CodeBase.Services.Camera;
using ECM.Components;
using ECM.Controllers;
using ECM.Examples;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class BlockMovementOnCameraPan : MonoBehaviour
    {
        private CameraService _cameraService;
        private CharacterMovement _characterMovement;
        private FPS_CustomController _fpsCustomController;

        [Inject]
        private void Construct(CameraService cameraService) => 
            _cameraService = cameraService;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _fpsCustomController = GetComponent<FPS_CustomController>();
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

        private void IsEnabled(bool isBlocked)
        {
            _fpsCustomController.pause = isBlocked;
            _characterMovement.Pause(isBlocked, false);
        }
    }
}