using System.Collections.Generic;
using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.Gameplay.Terrain
{
    public class TerrainLayerChanger
    {
        public void Change(UnityEngine.Terrain terrain, TerrainLayerType terrainLayerType, List<Transform> targetPositions, float brushSize)
        {
            foreach (Transform targetPosition in targetPositions)
            {
                TerrainData terrainData = terrain.terrainData;
                int terrainPosX = (int)((targetPosition.position.x - terrain.transform.position.x) / terrainData.size.x *
                                        terrainData.alphamapWidth);
                int terrainPosZ = (int)(((targetPosition.position.z - terrain.transform.position.z) / terrainData.size.z) *
                                        terrainData.alphamapHeight);

                int drawSize = Mathf.RoundToInt(brushSize / terrainData.size.x * terrainData.alphamapWidth); // размер кисти в пикселях на карте высот

                float[,,] splatmapData = terrainData.GetAlphamaps(terrainPosX - drawSize / 2, terrainPosZ - drawSize / 2,
                    drawSize, drawSize);

                for (int i = 0; i < drawSize; i++)
                {
                    for (int j = 0; j < drawSize; j++)
                    {
                        splatmapData[i, j, (int)terrainLayerType] = 1f; // устанавливаем значение текстуры в заданном слое

                        for (int k = 0; k < terrainData.alphamapLayers; k++)
                        {
                            if (k != (int)terrainLayerType)
                                splatmapData[i, j, k] = 0f; // обнуляем все остальные текстуры в остальных слоях
                        }
                    }
                }

                terrainData.SetAlphamaps(terrainPosX - drawSize / 2, terrainPosZ - drawSize / 2, splatmapData);
            }
        }
    }
}