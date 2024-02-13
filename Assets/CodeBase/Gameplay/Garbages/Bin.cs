using System;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using CodeBase.Services.TriggerObserve;
using CodeBase.UI.Effects;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Garbages
{
    public class Bin : MonoBehaviour
    {
        public TriggerObserver GarbageObserver;
        public GarbageType GarbageType;
        public Transform GarbagePosition;

        private EffectCreator _effectCreator;

        private void Awake()
        {
            _effectCreator = GetComponent<EffectCreator>();
        }


        private void OnCollisionEnter(Collision other)
        {
            if(!other.gameObject.TryGetComponent(out Garbage garbage))
                return;
            
            if(garbage.GarbageType != GarbageType)
                return;
            
            _effectCreator.CreateAndPlay(null, GarbagePosition.position);
        }
    }
}