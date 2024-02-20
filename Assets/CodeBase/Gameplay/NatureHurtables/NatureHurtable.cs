using System;
using CodeBase.Enums;
using CodeBase.Gameplay.CleanUpSystem;
using CodeBase.Gameplay.NatureDamageables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class NatureHurtable : MonoBehaviour, ICleanUp
    {
        public NatureHurtableType Id;
        
        public event Action<NatureDamageable> OnHurt;

        public event Action Destroyed;

        public void Hurt(NatureDamageable natureDamageable)
        {
            natureDamageable.TakeDamage();
            OnHurt?.Invoke(natureDamageable);
        }

        public void CleanUp()
        {
            Destroyed?.Invoke();
        }
    }
}