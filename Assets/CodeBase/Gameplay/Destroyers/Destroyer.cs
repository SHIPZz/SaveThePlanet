using CodeBase.Gameplay.DestroyableObjects;
using UnityEngine;

namespace CodeBase.Gameplay.Destroyers
{
    public class Destroyer : MonoBehaviour
    {
        public void Destroy(DestroyableObject destroyableObject)
        {
            destroyableObject.Destroy();
        }
    }
}