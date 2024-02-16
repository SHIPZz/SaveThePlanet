using System;
using CodeBase.Enums;
using CodeBase.Services.Factories;
using CodeBase.UI.Effects;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.GarbageDetection
{
    public class EffectOnRecover : MonoBehaviour
    {
        private const float AutoDestroyTime = 2.5f;
        
        public EffectType EffectType = EffectType.MagicZoneGreen;

        private RecoverOnClearGarbageZone _recoverOnClearGarbageZone;
        private UIFactory _uiFactory;

        [Inject]
        private void Construct(UIFactory uiFactory) => 
            _uiFactory = uiFactory;

        private void Awake() => 
            _recoverOnClearGarbageZone = GetComponent<RecoverOnClearGarbageZone>();

        private void OnEnable() => 
            _recoverOnClearGarbageZone.Recovered += Play;

        private void OnDisable() => 
            _recoverOnClearGarbageZone.Recovered -= Play;

        private void Play(GarbageDeathable garbageDeathable)
        {
           Effect effect = _uiFactory.CreateAndPlay(EffectType, null, garbageDeathable.transform.position, Quaternion.identity);
           effect.SetAutoDestroy(AutoDestroyTime);
        }
    }
}