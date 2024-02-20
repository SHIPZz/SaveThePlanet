using CodeBase.Gameplay.CleanUpSystem;
using CodeBase.Services.Providers.CameraProviders;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class CameraShakeOnDestroyable : MonoBehaviour, ICleanUp
    {
        public float Strength = 15;
        public float Duration = 0.5f;
        public int Vibration = 5;

        private CameraProvider _cameraProvider;

        [Inject]
        private void Construct(CameraProvider cameraProvider) => 
            _cameraProvider = cameraProvider;

        public void CleanUp() => 
            Shake();

        private void Shake() => 
            _cameraProvider.Camera.DOShakeRotation(Duration, Strength, Vibration);
    }
}