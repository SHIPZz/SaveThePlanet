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
        
        public event Action<Damageable> OnHurt;

        public event Action Destroyed;

        public void Hurt(Damageable damageable)
        {
            damageable.TakeDamage();
            OnHurt?.Invoke(damageable);
        }

        public void CleanUp()
        {
            Destroyed?.Invoke();
        }
    }
}