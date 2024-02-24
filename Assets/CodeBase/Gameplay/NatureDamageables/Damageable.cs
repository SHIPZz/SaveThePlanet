using System;
using CodeBase.Gameplay.NatureDamageables;
using UnityEngine;


public class Damageable : MonoBehaviour, IDamageable
{
    public event Action Damaged;

    public void TakeDamage()
    {
        Damaged?.Invoke();
    }
}