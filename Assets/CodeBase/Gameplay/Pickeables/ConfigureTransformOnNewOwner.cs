using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class ConfigureTransformOnNewOwner : MonoBehaviour
    {
        public Vector3 Rotation;
        public Vector3 Position = new Vector3(0.23f, 0.95f, 0.51f);
        
        private SetOwnerOnPickUp _setOwnerOnPickUp;

        private void Awake() => 
            _setOwnerOnPickUp = GetComponent<SetOwnerOnPickUp>();

        private void OnEnable() => 
            _setOwnerOnPickUp.NewOwnerSet += Configure;

        private void OnDisable() => 
            _setOwnerOnPickUp.NewOwnerSet -= Configure;

        private void Configure()
        {
            transform.localRotation = Quaternion.Euler(Rotation);
            transform.localPosition = Position;
        }
    }
}