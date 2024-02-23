using System;
using CodeBase.Gameplay.CameraPans;
using CodeBase.Services.Providers.CameraProviders;
using CodeBase.Services.UI;
using Cysharp.Threading.Tasks;

namespace CodeBase.Services.Camera
{
    public class CameraService
    {
        private readonly CameraProvider _cameraProvider;
        private readonly UIService _uiService;
        private CameraPan _target;

        public event Action MovingStarted;
        public event Action MovingFinished;

        public CameraService(CameraProvider cameraProvider, UIService uiService)
        {
            _uiService = uiService;
            _cameraProvider = cameraProvider;
        }

        public async UniTaskVoid MoveToTarget(CameraPan target, float backDuration, Action onComplete = null, Action onTargetReached = null)
        {
            _uiService.CloseAllWindows();

            while (_cameraProvider.CameraFollower.IsMovingToTarget)
            {
                await UniTask.Yield();
            }

            MovingStarted?.Invoke();

            _cameraProvider.CameraFollower.MoveTo(target.TargetPosition, backDuration, () => OnCameraMovementCompleted(onComplete), onTargetReached);
        }

        private void OnCameraMovementCompleted(Action onComplete)
        {
            _uiService.OpenHud();
            onComplete?.Invoke();
            MovingFinished?.Invoke();
        }
    }
}