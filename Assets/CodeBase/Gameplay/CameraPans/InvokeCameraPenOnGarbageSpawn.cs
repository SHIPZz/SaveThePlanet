using System;
using CodeBase.Gameplay.Garbages;
using UnityEngine;

namespace CodeBase.Gameplay.CameraPans
{
    public class InvokeCameraPenOnGarbageSpawn : MonoBehaviour
    {
        private CameraPan _cameraPan;
        private GarbageSpawnZone _garbageSpawnZone;

        private void Awake()
        {
            _cameraPan = GetComponent<CameraPan>();
            _garbageSpawnZone = GetComponent<GarbageSpawnZone>();
        }

        private void OnEnable()
        {
            _garbageSpawnZone.Spawned += InvokeCameraPan;
        }

        private void OnDisable()
        {
            _garbageSpawnZone.Spawned -= InvokeCameraPan;
        }

        private void InvokeCameraPan()
        {
            _cameraPan.Move();
        }
    }
}