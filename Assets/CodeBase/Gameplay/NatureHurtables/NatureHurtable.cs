using System;
using CodeBase.Gameplay.NatureDamageables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class NatureHurtable : MonoBehaviour
    {
        public event Action OnHurt;
        public event Action OnDestroyed;
        
        public void Hurt(NatureDamageable natureDamageable)
        {
            natureDamageable.TakeDamage();
            OnHurt?.Invoke();
        }

        [Button]
        public void Destroy()
        {
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}