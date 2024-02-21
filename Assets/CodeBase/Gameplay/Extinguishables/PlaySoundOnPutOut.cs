using UnityEngine;

namespace CodeBase.Gameplay.Extinguishables
{
    public class PlaySoundOnPutOut : MonoBehaviour
    {
        public AudioSource Sound;

        private Extinguishable _extinguishable;

        private void Awake() => 
            _extinguishable = GetComponent<Extinguishable>();

        private void OnEnable() => 
            _extinguishable.PutOut += OnPutOut;

        private void OnDisable() => 
            _extinguishable.PutOut -= OnPutOut;

        private void OnPutOut(Vector3 target, Vector3 rotation) => 
            Sound.Play();
    }
}