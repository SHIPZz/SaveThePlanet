using System;
using CodeBase.Animations;
using UnityEngine;

namespace CodeBase.Gameplay.Garbages
{
    [RequireComponent(typeof(TransformScaleAnim))]
    public class ScaleOnGarbageSpawned : MonoBehaviour
    {
        public GarbageSpawnZone GarbageSpawnZone;

        private TransformScaleAnim _transformScaleAnim;

        private void Awake()
        {
            _transformScaleAnim = GetComponent<TransformScaleAnim>();
        }

        private void OnEnable()
        {
            GarbageSpawnZone.Spawned += DoScale;
            GarbageSpawnZone.GarbagesDestroyed += DoUnScale;
        }

        private void OnDisable()
        {
            GarbageSpawnZone.Spawned -= DoScale;
            GarbageSpawnZone.GarbagesDestroyed -= DoUnScale;
        }

        private void DoUnScale()
        {
            _transformScaleAnim.UnScale();
        }


        private void DoScale() => 
            _transformScaleAnim.ToScale();
    }
}