using System;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    public class ChangeTerrainOnHurtable : MonoBehaviour
    {
        public Terrain GreenTerrain;
        public Terrain DeadTerrain;

        private NatureHurtable _natureHurtable;

        private void Awake()
        {
            _natureHurtable = GetComponent<NatureHurtable>();
        }

        private void OnEnable()
        {
            _natureHurtable.OnHurt += ChangeToDeadTerrain;
            _natureHurtable.OnDestroyed += ChangeToGreenTerrain;
        }

        private void OnDisable()
        {
            _natureHurtable.OnHurt -= ChangeToDeadTerrain;
            _natureHurtable.OnDestroyed -= ChangeToGreenTerrain;
        }

        private void ChangeToDeadTerrain()
        {
            // GreenTerrain.gameObject.SetActive(false);
            // DeadTerrain.gameObject.SetActive(true);
        }
        
        private void ChangeToGreenTerrain()
        {
            // DeadTerrain.gameObject.SetActive(false);
            // GreenTerrain.gameObject.SetActive(true);
        }
    }
}