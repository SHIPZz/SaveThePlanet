using System;
using CodeBase.Enums;
using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Gameplay.Burnables
{
    [RequireComponent(typeof(EffectCreator))]
    [RequireComponent(typeof(Burnable))]
    public class EffectOnBurnable : MonoBehaviour
    {
        private EffectCreator _effectCreator;
        private Burnable _burnable;

        private void Awake()
        {
            _burnable = GetComponent<Burnable>();
            _effectCreator = GetComponent<EffectCreator>();
        }

        private void OnEnable() => 
            _burnable.Burned += PlayEffect;

        private void OnDisable() => 
            _burnable.Burned -= PlayEffect;

        private void PlayEffect(Burnable burnable)
        {
           Effect effect = _effectCreator.CreateAndPlay(null, burnable.transform.position);
            effect.SetAutoDestroy(2f);
        }
    }
}