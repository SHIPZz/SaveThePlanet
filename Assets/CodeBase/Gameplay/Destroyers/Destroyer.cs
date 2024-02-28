using System;
using CodeBase.Enums;
using CodeBase.Gameplay.DestroyableObjects;
using UnityEngine;

namespace CodeBase.Gameplay.Destroyers
{
    public class Destroyer : MonoBehaviour
    {
        public DestroyerType DestroyerType;

        public void Destroy(DestroyableObject destroyableObject)
        {
            destroyableObject.DoDestroy();
        }
    }
}