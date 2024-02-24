using System;

namespace CodeBase.Gameplay.NatureDamageables
{
    public interface IDamageable
    {
        event Action Damaged;
        void TakeDamage();
    }
}