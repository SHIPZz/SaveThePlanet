using System;
using UnityEngine;

namespace CodeBase.Gameplay.NatureDamageables
{
    public class NatureDamageable : MonoBehaviour
    {
        public event Action Damaged;

        public void TakeDamage()
        {
            Damaged?.Invoke();
        }
    }
}