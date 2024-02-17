using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Burnables
{
    public class Burnable : MonoBehaviour
    {
        public event Action<Burnable> Burned;
        public event Action<Burnable> Recovered;

        [Button]
        public void Recover()
        {
            Recovered?.Invoke(this);
        }
        
        [Button]
        public void Burn()
        {
            Burned?.Invoke(this);
        }
    }
}