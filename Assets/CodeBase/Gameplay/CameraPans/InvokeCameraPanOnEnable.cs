using System;
using CodeBase.Services.Camera;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.CameraPans
{
    public class InvokeCameraPanOnEnable : MonoBehaviour
    {
        public float Delay;
        private CameraService _cameraService;
        private CameraPan _cameraPan;

        [Inject]
        private void Construct(CameraService cameraService)
        {
            _cameraService = cameraService;
        }

        private void Awake()
        {
            _cameraPan = GetComponent<CameraPan>();
        }

        [Button]
        private void Start()
        {
            DOTween.Sequence().AppendInterval(Delay)
                .OnComplete(() => _cameraPan.Move());
        }
    }
}