using CodeBase.Gameplay.Camera;
using UnityEngine;

namespace CodeBase.Services.Providers.CameraProviders
{
    public class CameraProvider
    {
        public UnityEngine.Camera Camera;
        public CameraFollower CameraFollower;
        public Transform CameraPivot;
        public UnityEngine.Camera CameraParticle;
    }
}