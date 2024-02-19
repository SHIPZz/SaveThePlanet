using System;
using CodeBase.Gameplay.CleanUpSystem;
using CodeBase.Gameplay.NatureDamageables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class NatureHurtable : MonoBehaviour, ICleanUp
    {
        public event Action<NatureDamageable> OnHurt;
        public event Action Destroyed;

        public event Action CleanedUp;

        public void Hurt(NatureDamageable natureDamageable)
        {
            natureDamageable.TakeDamage();
            OnHurt?.Invoke(natureDamageable);
        }

        public void Destroy()
        {
            CleanedUp?.Invoke();
        }

        public void CleanUp()
        {
            Destroyed?.Invoke();
        }
    }
}