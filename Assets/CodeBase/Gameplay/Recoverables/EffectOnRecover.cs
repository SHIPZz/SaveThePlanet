using System;
using CodeBase.Enums;
using CodeBase.UI.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Recoverables
{
    [RequireComponent(typeof(EffectCreator))]
    [RequireComponent(typeof(Recoverable))]
    public class EffectOnRecover : MonoBehaviour, IRecoverableEvent
    {
        private EffectCreator _effectCreator;

        private void Awake()
        {
            _effectCreator = GetComponent<EffectCreator>();
        }

        [Button]
        public void OnRecovered()
        {
            SpawnEffect();
        }

        private void SpawnEffect() => 
            _effectCreator.CreateAndPlay(null, transform.position);
    }
}