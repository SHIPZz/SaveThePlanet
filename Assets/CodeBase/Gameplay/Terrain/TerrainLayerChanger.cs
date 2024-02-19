using System.Collections.Generic;
using CodeBase.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Terrain
{
    public class TerrainLayerChanger : MonoBehaviour
    {
        public UnityEngine.Terrain Terrain; 
        public TerrainLayerType TerrainLayerIndex; 
        public List<Transform> TargetPositions; 
        public float BrushSize = 10f;

        public void SetTerrainLayer(TerrainLayerType terrainLayerType) =>
            TerrainLayerIndex = terrainLayerType;

        [Button]
        public void Change()
        {
            foreach (Transform targetPosition in TargetPositions)
            {
                TerrainData terrainData = Terrain.terrainData;
                int terrainPosX = (int)((targetPosition.position.x - Terrain.transform.position.x) / terrainData.size.x *
                                        terrainData.alphamapWidth);
                int terrainPosZ = (int)(((targetPosition.position.z - Terrain.transform.position.z) / terrainData.size.z) *
                                        terrainData.alphamapHeight);

                int drawSize = Mathf.RoundToInt(BrushSize / terrainData.size.x * terrainData.alphamapWidth); // размер кисти в пикселях на карте высот

                float[,,] splatmapData = terrainData.GetAlphamaps(terrainPosX - drawSize / 2, terrainPosZ - drawSize / 2,
                    drawSize, drawSize);

                for (int i = 0; i < drawSize; i++)
                {
                    for (int j = 0; j < drawSize; j++)
                    {
                        splatmapData[i, j, (int)TerrainLayerIndex] = 1f; // устанавливаем значение текстуры в заданном слое

                        for (int k = 0; k < terrainData.alphamapLayers; k++)
                        {
                            if (k != (int)TerrainLayerIndex)
                                splatmapData[i, j, k] = 0f; // обнуляем все остальные текстуры в остальных слоях
                        }
                    }
                }

                terrainData.SetAlphamaps(terrainPosX - drawSize / 2, terrainPosZ - drawSize / 2, splatmapData);
            }
        }
    }
}