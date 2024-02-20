using System;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Gameplay.DoDestroySystem;
using UnityEngine;

namespace CodeBase.Gameplay.Destroyers
{
    [RequireComponent(typeof(DoDestroy))]
    public class DestroyOnDestroyableObject : MonoBehaviour
    {
        private DoDestroy _doDestroy;

        private void Awake() => 
            _doDestroy = GetComponent<DoDestroy>();

        private void OnCollisionEnter(Collision other) => 
            TryDestroy(other.gameObject);

        private void OnTriggerEnter(Collider other) => 
            TryDestroy(other.gameObject);

        private void TryDestroy(GameObject targetGameObject)
        {
            if (!targetGameObject.TryGetComponent(out DestroyableObject destroyableObject))
                return;

            _doDestroy.Do();
        }
    }
}