using CodeBase.Services.Camera;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.CameraPans
{
    public class CameraPan : MonoBehaviour
    {
        public Transform TargetPosition;
        public Vector3 Offset;
        public bool OwnTransform; 
        
        private CameraService _cameraService;

        [Inject]
        private void Construct(CameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Move()
        {
            if (OwnTransform)
                TargetPosition = transform;
            
            _cameraService.MoveToTarget(this,1.5f).Forget();
        }
    }
}