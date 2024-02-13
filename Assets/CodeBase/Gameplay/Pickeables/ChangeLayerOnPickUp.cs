using System;
using System.Collections.Generic;
using CodeBase.Constant;
using UnityEngine;

namespace CodeBase.Gameplay.Pickeables
{
    public class ChangeLayerOnPickUp : MonoBehaviour
    {
        [Layer] public int PickUpLayer;
        
        private Pickeable _pickeable;

        private void Awake() =>
            _pickeable = GetComponent<Pickeable>();

        private void OnEnable()
        {
            _pickeable.OnPickedUp += SetLayer;
        }

        private void OnDisable()
        {
            _pickeable.OnPickedUp -= SetLayer;
        }
        
        private void SetLayer(Transform obj)
        {
            gameObject.layer = PickUpLayer;
        }
    }
}