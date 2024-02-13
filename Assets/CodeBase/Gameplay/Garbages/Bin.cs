using System;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using CodeBase.Services.TriggerObserve;
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
        public EffectType EffectType;
        
        private UIFactory _uiFactory;

        [Inject]
        private void Construct(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(!other.gameObject.TryGetComponent(out Garbage garbage))
                return;
            
            if(garbage.GarbageType != GarbageType)
                return;
            
            _uiFactory.CreateAndPlay(EffectType, null, GarbagePosition.position, Quaternion.identity);
        }
    }
}