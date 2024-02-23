using System;
using CodeBase.Services.Providers.CameraProviders;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class CameraShakeOnPlayerThrown : MonoBehaviour
    {
        public float Strength = 15;
        public float Duration = 0.5f;
        public int Vibration = 5;

        private CameraProvider _cameraProvider;
        private PlayerThrower _playerThrower;
        
        [Inject]
        private void Construct(CameraProvider cameraProvider) =>
            _cameraProvider = cameraProvider;

        private void Awake() => 
            _playerThrower = GetComponent<PlayerThrower>();

        private void OnEnable() => 
            _playerThrower.Thrown += Shake;

        private void OnDisable() => 
            _playerThrower.Thrown -= Shake;

        private void Shake()
        {
            _cameraProvider.Camera.DOShakeRotation(Duration, Strength, Vibration);
        }
    }
}