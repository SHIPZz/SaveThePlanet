using System;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    public class PushAwayOnWrongGarbage : MonoBehaviour
    {
        public float Force;

        private Bin _bin;

        private void Awake()
        {
            _bin = GetComponent<Bin>();
        }

        private void OnEnable()
        {
            _bin.WrongGarbage += Push;
        }

        private void OnDisable()
        {
            _bin.WrongGarbage -= Push;
        }

        private void Push(Garbage garbage)
        {
            var garbageRb = garbage.GetComponent<Rigidbody>();
            garbageRb.AddForce(transform.forward * Force, ForceMode.Impulse);
        }
    }
}