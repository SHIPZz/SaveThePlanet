using CodeBase.Services.Camera;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.CameraPans
{
    public class CameraPan : MonoBehaviour
    {
        public Vector3 Offset;
        private CameraService _cameraService;

        [Inject]
        private void Construct(CameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public void Move()
        {
            _cameraService.MoveToTarget(this,1.5f);
        }
    }
}