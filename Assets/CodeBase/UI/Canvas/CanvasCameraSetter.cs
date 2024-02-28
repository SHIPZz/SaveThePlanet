using System;
using CodeBase.Services.Providers.CameraProviders;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Canvas
{
    public class CanvasCameraSetter : MonoBehaviour
    {
        public bool ParticleCamera;
        public bool DefaultCamera;
        public UnityEngine.Canvas Canvas;
        private CameraProvider _cameraProvider;

        [Inject]
        private void Construct(CameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }

        private void Start()
        {
            if (ParticleCamera)
                Canvas.worldCamera = _cameraProvider.CameraParticle;

            if (DefaultCamera)
                Canvas.worldCamera = _cameraProvider.Camera;
        }
    }
}