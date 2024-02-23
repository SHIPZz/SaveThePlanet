﻿using System;
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

        public bool IsMoving { get; private set; }

        public CameraService(CameraProvider cameraProvider, UIService uiService)
        {
            _uiService = uiService;
            _cameraProvider = cameraProvider;
        }

        public void MoveToTarget(CameraPan target, float backDuration, Action onComplete = null,
            Action onTargetReached = null)
        {
            _uiService.CloseAllWindows();
            MovingStarted?.Invoke();
            IsMoving = true;

            _cameraProvider.CameraFollower.MoveTo(target.transform, backDuration, () => OnCameraMovementCompleted(onComplete), onTargetReached);
        }

        private void OnCameraMovementCompleted(Action onComplete)
        {
            _uiService.OpenHud();
            IsMoving = false;
            onComplete?.Invoke();
            MovingFinished?.Invoke();
        }
    }
}