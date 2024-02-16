using System;
using CodeBase.Services.Providers.CameraProviders;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.TransformCamera
{
    public class TransformCameraFacing : MonoBehaviour
    {
        private CameraProvider _cameraProvider;

        [Inject]
        private void Construct(CameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }
        
        private void Update()
        {
            if( _cameraProvider.Camera == null)
                return;

            transform.rotation = Quaternion.LookRotation(_cameraProvider.Camera.transform.forward);
        }
    }
}