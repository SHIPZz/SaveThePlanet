using System;
using CodeBase.Gameplay.NatureDamageables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class RecoverDamagedNatureOnDestroy : MonoBehaviour
    {
        private NatureHurtable _natureHurtable;
        private AddHurtNatureToListOnHurt _addHurtNatureToListOnHurt;

        private void Awake()
        {
            _natureHurtable = GetComponent<NatureHurtable>();
            _addHurtNatureToListOnHurt = GetComponent<AddHurtNatureToListOnHurt>();
        }

        private void OnEnable() => 
            _natureHurtable.Destroyed += Recover;

        private void OnDisable() => 
            _natureHurtable.Destroyed -= Recover;

        private void Recover()
        {
            foreach (NatureDamageable natureDamageable in _addHurtNatureToListOnHurt.NatureDamageables)
            {
                natureDamageable.Recover();
            }
        }
    }
}