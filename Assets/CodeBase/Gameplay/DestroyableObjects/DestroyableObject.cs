using CodeBase.Enums;
using CodeBase.Gameplay.DoDestroySystem;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    [RequireComponent(typeof(DoDestroy))]
    public class DestroyableObject : MonoBehaviour
    {
        public DestroyableTypeId DestroyableTypeId;

        private DoDestroy _doDestroy;

        private void Awake()
        {
            _doDestroy = GetComponent<DoDestroy>();
        }

        public void DoDestroy()
        {
            _doDestroy.Do();
        }
    }
}