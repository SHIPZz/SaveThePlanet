using CodeBase.Enums;
using CodeBase.Gameplay.NatureDamageables;
using CodeBase.Gameplay.Terrain;
using UnityEngine;

namespace CodeBase.Gameplay.NatureHurtables
{
    [RequireComponent(typeof(TerrainLayerChanger))]
    [RequireComponent(typeof(NatureHurtable))]
    public class ChangeTerrainLayerOnNatureHurt : MonoBehaviour
    {
        public TerrainLayerType HurtLayerType;
        public TerrainLayerType NormalLayerType;

        private NatureHurtable _natureHurtable;
        private TerrainLayerChanger _terrainLayerChanger;

        private void Awake()
        {
            _natureHurtable = GetComponent<NatureHurtable>();
            _terrainLayerChanger = GetComponent<TerrainLayerChanger>();
        }

        private void OnEnable()
        {
            _natureHurtable.OnHurt += ChangeToMud;
            _natureHurtable.Destroyed += ChangeToGrass;
        }

        private void OnDisable()
        {
            _natureHurtable.OnHurt -= ChangeToMud;
            _natureHurtable.Destroyed -= ChangeToGrass;
        }

        private void ChangeToGrass()
        {
            print("grass");
            _terrainLayerChanger.SetTerrainLayer(NormalLayerType);
            Change();
        }

        private void ChangeToMud(NatureDamageable natureDamageable)
        {
            _terrainLayerChanger.SetTerrainLayer(HurtLayerType);
            Change();
        }

        private void Change() => 
            _terrainLayerChanger.Change();
    }
}