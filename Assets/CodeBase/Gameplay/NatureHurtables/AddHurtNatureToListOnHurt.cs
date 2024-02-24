using System;
using System.Collections.Generic;
using CodeBase.Gameplay.NatureDamageables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class AddHurtNatureToListOnHurt : MonoBehaviour
    {
        private List<Damageable> _natureDamageables = new();
        private NatureHurtable _natureHurtable;

        public IReadOnlyList<Damageable> NatureDamageables => _natureDamageables;

        private void Awake() => 
            _natureHurtable = GetComponent<NatureHurtable>();

        private void OnEnable() => 
            _natureHurtable.OnHurt += Add;

        private void OnDisable() => 
            _natureHurtable.OnHurt -= Add;

        public void Add(Damageable damageable) =>
            _natureDamageables.Add(damageable);
    }
}