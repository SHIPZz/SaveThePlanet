using CodeBase.Gameplay.Garbages;
using UnityEngine;

namespace CodeBase.Gameplay.Watter
{
    public class PolluteWaterOnGarbage : MonoBehaviour
    {
        public GarbageSpawnZone GarbageSpawnZone;
        
        private WaterPollution _waterPollution;
        
        private void Awake() => 
            _waterPollution = GetComponent<WaterPollution>();

        private void OnEnable()
        {
            GarbageSpawnZone.GarbagesDestroyed += Clear;
            GarbageSpawnZone.Spawned += Pollute;
        }

        private void OnDisable()
        {
            GarbageSpawnZone.GarbagesDestroyed -= Clear;
            GarbageSpawnZone.Spawned -= Pollute;
        }

        private void Clear() => 
            _waterPollution.Clear();

        private void Pollute() => 
            _waterPollution.Pollute();
    }
}