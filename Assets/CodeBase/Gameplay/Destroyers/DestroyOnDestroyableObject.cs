using System;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Gameplay.DoDestroySystem;
using UnityEngine;

namespace CodeBase.Gameplay.Destroyers
{
    [RequireComponent(typeof(DoDestroy))]
    [RequireComponent(typeof(InvokeDestroyerOnTrigger))]
    public class DestroyOnDestroyableObject : MonoBehaviour
    {
        private DoDestroy _doDestroy;
        private InvokeDestroyerOnTrigger _invokeDestroyerOnTrigger;

        private void Awake()
        {
            _doDestroy = GetComponent<DoDestroy>();
            _invokeDestroyerOnTrigger = GetComponent<InvokeDestroyerOnTrigger>();
        }

        private void OnEnable() => 
            _invokeDestroyerOnTrigger.ShouldDestroy += TryDestroy;

        private void OnDisable() => 
            _invokeDestroyerOnTrigger.ShouldDestroy -= TryDestroy;

        private void TryDestroy() => 
            _doDestroy.Do();
    }
}