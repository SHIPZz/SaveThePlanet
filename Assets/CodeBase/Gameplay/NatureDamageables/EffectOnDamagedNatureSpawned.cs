using System;
using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Gameplay.NatureDamageables
{
    [RequireComponent(typeof(EffectCreator))]
    public class EffectOnDamagedNatureSpawned : MonoBehaviour
    {
        private EffectCreator _effectCreator;

        private void Awake()
        {
            _effectCreator = GetComponent<EffectCreator>();
        }

        private void Start()
        {
            _effectCreator.CreateAndPlay(null, transform.position);
        }
    }
}