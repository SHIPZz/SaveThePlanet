using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Services.Providers.GameProviders;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Terrain
{
    public class ChangeTerrainLayerOnApplicationQuit : MonoBehaviour
    {
        public TerrainLayerType TargetLayerType;
        public List<Transform> Positions;
        public float BrushSize = 10;

        private TerrainLayerChanger _terrainLayerChanger;
        private GameProvider _gameProvider;

        [Inject]
        private void Construct(GameProvider gameProvider, TerrainLayerChanger terrainLayerChanger)
        {
            _terrainLayerChanger = terrainLayerChanger;
            _gameProvider = gameProvider;
        }

        private void Awake()
        {
            _terrainLayerChanger.Change(_gameProvider.Terrain, TargetLayerType, Positions, BrushSize);
        }
    }
}