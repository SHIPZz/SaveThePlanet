using System;
using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Gameplay.CleanUpSystem;
using CodeBase.Gameplay.NatureDamageables;
using CodeBase.Gameplay.Terrain;
using CodeBase.Services.Providers.GameProviders;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.NatureHurtables
{
    [RequireComponent(typeof(NatureHurtable))]
    public class ChangeTerrainLayerOnNatureHurt : MonoBehaviour, ICleanUp
    {
        public TerrainLayerType HurtLayerType;
        public TerrainLayerType NormalLayerType;
        public List<Transform> Positions;
        public float BrushSize;

        private NatureHurtable _natureHurtable;
        private TerrainLayerChanger _terrainLayerChanger;
        private GameProvider _gameProvider;
        private bool _isMud;

        [Inject]
        private void Construct(GameProvider gameProvider, TerrainLayerChanger terrainLayerChanger)
        {
            _terrainLayerChanger = terrainLayerChanger;
            _gameProvider = gameProvider;
        }
        
        private void Awake() => 
            _natureHurtable = GetComponent<NatureHurtable>();

        private void OnEnable() => 
            _natureHurtable.OnHurt += ChangeToMud;

        private void OnDisable() => 
            _natureHurtable.OnHurt -= ChangeToMud;

        private void OnApplicationQuit() => 
            ChangeToGrass();

        public void CleanUp() => 
            ChangeToGrass();

        [Button]
        private void ChangeToGrass()
        {
            _terrainLayerChanger.Change(_gameProvider.Terrain, NormalLayerType, Positions, BrushSize);
            _isMud = false;
        }

        [Button]
        private void ChangeToMud(Damageable damageable)
        {
            if(_isMud)
                return;
            
            _isMud = true;
            _terrainLayerChanger.Change(_gameProvider.Terrain, HurtLayerType, Positions, BrushSize);
        }
    }
}