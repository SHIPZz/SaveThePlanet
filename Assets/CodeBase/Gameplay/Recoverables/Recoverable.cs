using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Recoverables
{
    public class Recoverable : MonoBehaviour
    {
        private IRecoverableEvent[] _recoverableEvents;

        private void Awake()
        {
            _recoverableEvents = GetComponents<IRecoverableEvent>();
        }

        [Button]
        public void Recover()
        {
            gameObject.SetActive(true);

            foreach (IRecoverableEvent recoverableEvent in _recoverableEvents)
            {
                recoverableEvent.OnRecovered();
            }
        }
    }
}