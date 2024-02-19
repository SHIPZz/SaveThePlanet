using System;
using UnityEngine;

namespace CodeBase.Gameplay.NatureDamageables
{
    public class NatureDamageable : MonoBehaviour
    {
        public event Action Damaged;
        public event Action Recovered;
        
        public void TakeDamage()
        {
            Damaged?.Invoke();
        }

        public void Recover()
        {
            gameObject.SetActive(true);
            Recovered?.Invoke();
        }
    }
}