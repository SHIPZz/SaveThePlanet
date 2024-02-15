﻿using System.Collections.Generic;
using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.Gameplay.DestroyableObjects
{
    public class DestroyableObjectPart : MonoBehaviour
    {
        public List<Rigidbody> Parts;
        public DestroyableTypeId DestroyableTypeId;

        private List<Vector3> _randomVectors = new()
        {
            { Vector3.back },
            { Vector3.forward },
            { Vector3.left },
            { Vector3.right },
        };

        public void Activate()
        {
            Vector3 randomVector = _randomVectors[Random.Range(0, _randomVectors.Count - 1)];
            
            Parts.ForEach(x =>
            {
                x.isKinematic = false;
                x.AddForce(randomVector* 15f, ForceMode.Impulse);
            });
        }
    }
}