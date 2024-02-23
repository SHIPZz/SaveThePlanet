using System;
using CodeBase.Gameplay.CameraPans;
using CodeBase.Services.Providers.CameraProviders;
using CodeBase.Services.UI;

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

        public bool IsMoving { get; private set; }

        public void MoveToTarget(CameraPan target, float backDuration, Action onComplete = null,
            Action onTargetReached = null)
        {
            _uiService.CloseAllWindows();
            MovingStarted?.Invoke();
            IsMoving = true;

            _cameraProvider.CameraFollower.MoveTo(target.transform, backDuration, () =>
            {
                _uiService.OpenHud();
                MovingFinished?.Invoke();
                IsMoving = false;
                onComplete?.Invoke();
            }, onTargetReached);
        }

        public void MoveToLastTarget()
        {
            // if (_shownObjects.Contains(_target.GameItemType))
            //     return;
            //
            // _uiService.SetActiveUI<HudWindow>(false);
            // _cameraProvider.CameraFollower.Block(true);
            // _cameraProvider.CameraFollower.MoveTo(_target.transform, () => _uiService.SetActiveUI(true));
            // _shownObjects.Add(_target.GameItemType);
        }
    }
}