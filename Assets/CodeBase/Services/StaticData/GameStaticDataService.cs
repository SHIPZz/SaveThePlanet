using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.Gameplay.DestroyableObjects;
using CodeBase.Gameplay.Destroyers;
using CodeBase.Gameplay.Extinguishables;
using CodeBase.Gameplay.Fireables;
using CodeBase.Gameplay.GarbageDetection;
using CodeBase.Gameplay.Garbages;
using CodeBase.Gameplay.NatureDamageables;
using CodeBase.Gameplay.NatureHurtables;
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
        private readonly Dictionary<DamagedNatureType, DamagedNature> _damagedNatures;
        private readonly Dictionary<NatureHurtableType, NatureHurtable> _hurtableNatures;
        private readonly Dictionary<DestroyerType, Destroyer> _destroyers;
        private readonly Dictionary<ExtinguishableType, Extinguishable> _extinguishables;
        private readonly Dictionary<FireableType, Fireable> _fireables;

        public GameStaticDataService()
        {
            _destroyableObjectPrefabs = Resources.LoadAll<DestroyableObjectPart>(AssetPath.DestroyableObjectParts)
                .ToDictionary(x => x.DestroyableTypeId, x => x);

            _garbages = Resources.LoadAll<Garbage>(AssetPath.Garbages);

            _garbageDeathables = Resources.LoadAll<GarbageDeathable>(AssetPath.GarbageDeathables)
                .ToDictionary(x => x.Id, x => x);

            _damagedNatures = Resources.LoadAll<DamagedNature>(AssetPath.DamagedNatures)
                .ToDictionary(x => x.DamagedNatureType, x => x);

            _playerData = Resources.Load<PlayerData>(AssetPath.PlayerData);

            _hurtableNatures = Resources.LoadAll<NatureHurtable>(AssetPath.NatureHurtables)
                .ToDictionary(x => x.Id, x => x);

            _destroyers = Resources.LoadAll<Destroyer>(AssetPath.Destroyers)
                .ToDictionary(x => x.DestroyerType, x => x);

            _fireables = Resources.LoadAll<Fireable>(AssetPath.Fireables)
                .ToDictionary(x => x.FireableType, x => x);
            
            _extinguishables = Resources.LoadAll<Extinguishable>(AssetPath.Extinguishables)
                .ToDictionary(x => x.ExtinguishableType, x => x);
        }


        public Fireable Get(FireableType id)
            => _fireables[id];
        
        public Extinguishable Get(ExtinguishableType id)
            => _extinguishables[id];

        public NatureHurtable Get(NatureHurtableType id)
            => _hurtableNatures[id];

        public GarbageDeathable Get(string id) =>
            _garbageDeathables[id];

        public DamagedNature Get(DamagedNatureType id) =>
            _damagedNatures[id];

        public List<Garbage> GetAllGarbages() =>
            _garbages.ToList();

        public PlayerData GetPlayerData() =>
            _playerData;

        public Destroyer Get(DestroyerType id) =>
            _destroyers[id];

        public DestroyableObjectPart Get(DestroyableTypeId destroyableTypeId) =>
            _destroyableObjectPrefabs[destroyableTypeId];
    }
}