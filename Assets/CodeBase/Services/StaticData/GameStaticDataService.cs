using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.ScriptableObjects.Player;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class GameStaticDataService
    {
        private readonly Dictionary<DestroyableTypeId, DestroyableObjectPart> _destroyableObjectPrefabs;
        private readonly PlayerData _playerData;

        public GameStaticDataService()
        {
            _destroyableObjectPrefabs = Resources.LoadAll<DestroyableObjectPart>(AssetPath.DestroyableObjectParts)
                .ToDictionary(x => x.DestroyableTypeId, x => x);

            _playerData = Resources.Load<PlayerData>(AssetPath.PlayerData);
        }

        public PlayerData GetPlayerData()
        {
            return _playerData;
        }

        public DestroyableObjectPart Get(DestroyableTypeId destroyableTypeId) => 
            _destroyableObjectPrefabs[destroyableTypeId];
    }
}