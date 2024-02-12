using System;
using UnityEngine;

namespace CodeBase.Gameplay.CampFireSystem
{
    public class CampFireMediator : MonoBehaviour
    {
        private CampFire _campFire;

        private void Awake()
        {
            _campFire = GetComponent<CampFire>();
        }

        private void OnGUI()
        {
            if (Event.current.Equals(Event.KeyboardEvent("F")))
            {
                _campFire.TryDisable();
            }
        }
    }
}