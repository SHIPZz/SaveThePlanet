using System;
using CodeBase.Enums;
using CodeBase.Gameplay.Garbages;
using CodeBase.Gameplay.Pickeables;
using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Gameplay.Bins
{
    [RequireComponent(typeof(EffectCreator))]
    public class Bin : MonoBehaviour
    {
        public GarbageType GarbageType;
        public Transform GarbagePosition;

        private EffectCreator _effectCreator;

        public event Action<Garbage> WrongGarbage;

        private void Awake()
        {
            _effectCreator = GetComponent<EffectCreator>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent(out Garbage garbage))
                return;

            if (GarbageType != GarbageType.Generic && garbage.GarbageType != GarbageType)
            {
                WrongGarbage?.Invoke(garbage);
                return;
            }

            var pickeable = garbage.GetComponent<Pickeable>();
            pickeable.PickUpWithMovement(GarbagePosition);

            _effectCreator.CreateAndPlay(null, GarbagePosition.position);
        }
    }
}