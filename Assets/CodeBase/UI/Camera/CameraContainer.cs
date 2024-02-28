using CodeBase.Gameplay.Camera;
using UnityEngine;

namespace CodeBase.UI.Camera
{
    public class CameraContainer : MonoBehaviour
    {
        [field: SerializeField] public UnityEngine.Camera Camera { get; private set; }
        [field: SerializeField] public UnityEngine.Camera ParticleCamera { get; private set; }
        [field: SerializeField] public CameraFollower CameraFollower { get; private set; }
        [field: SerializeField] public Transform CameraPivot { get; private set; }
    }
}