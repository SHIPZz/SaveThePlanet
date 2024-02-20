using CodeBase.Gameplay.CleanUpSystem;
using CodeBase.Gameplay.NatureDamageables;
using CodeBase.Gameplay.Recoverables;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class RecoverDamagedNatureOnDestroy : MonoBehaviour, ICleanUp
    {
        private AddHurtNatureToListOnHurt _addHurtNatureToListOnHurt;

        private void Awake()
        {
            _addHurtNatureToListOnHurt = GetComponent<AddHurtNatureToListOnHurt>();
        }

        public void CleanUp()
        {
            Recover();
        }

        private void Recover()
        {
            foreach (NatureDamageable natureDamageable in _addHurtNatureToListOnHurt.NatureDamageables)
            {
                natureDamageable.GetComponent<Recoverable>().Recover();
            }
        }
    }
}