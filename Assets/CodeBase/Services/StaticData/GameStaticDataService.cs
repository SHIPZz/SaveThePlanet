using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Gameplay.GarbageDetection;
using CodeBase.Gameplay.Garbages;
using CodeBase.ScriptableObjects.Player;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class GameStaticDataService
    {
        private readonly Dictionary<DestroyableTypeId, DestroyableObjectPart> _destroyableObjectPrefabs;
        private readonly PlayerData _playerData;
        private readonly Garbage[] _garbages;
        private readonly Dictionary<string, GarbageDeathable> _garbageDeathables;

        public GameStaticDataService()
        {
            _destroyableObjectPrefabs = Resources.LoadAll<DestroyableObjectPart>(AssetPath.DestroyableObjectParts)
                .ToDictionary(x => x.DestroyableTypeId, x => x);

            _garbages = Resources.LoadAll<Garbage>(AssetPath.Garbages);

            _garbageDeathables = Resources.LoadAll<GarbageDeathable>(AssetPath.GarbageDeathables)
                .ToDictionary(x => x.Id, x => x);

            _playerData = Resources.Load<PlayerData>(AssetPath.PlayerData);
        }

        public GarbageDeathable Get(string id)
        {
            return _garbageDeathables[id];
        }

        public List<Garbage> GetAllGarbages()
        {
            return _garbages.ToList();
        }

        public PlayerData GetPlayerData()
        {
            return _playerData;
        }

        public DestroyableObjectPart Get(DestroyableTypeId destroyableTypeId) => 
            _destroyableObjectPrefabs[destroyableTypeId];
    }
}