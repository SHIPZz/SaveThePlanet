using System;
using CodeBase.Gameplay.Fireables;
using UnityEngine;

namespace CodeBase.Gameplay.Burnables
{
    public class BurnOnFireableTrigger : MonoBehaviour
    {
        private Burnable _burnable;
        private Fireable _fireable;

        private void Awake()
        {
            _burnable = GetComponent<Burnable>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.TryGetComponent(out Fireable fireable))
                return;
            
            if(_fireable != null)
                return;

            _fireable = fireable;
            _fireable.OnPutOut += _burnable.Recover;
            _burnable.Burn();
        }

        private void OnDisable()
        {
            if (_fireable != null)
                _fireable.OnPutOut -= _burnable.Recover;
        }
    }
}