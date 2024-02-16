using System.Linq;
using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Gameplay.GarbageDetection;
using CodeBase.Services.Factories;
using CodeBase.Services.WorldData;
using UnityEngine;

namespace CodeBase.Services.GarbageDeathableServices
{
    public class GarbageDeathableService
    {
        private readonly IWorldDataService _worldDataService;
        private GameFactory _gameFactory;

        public GarbageDeathableService(IWorldDataService worldDataService, GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _worldDataService = worldDataService;
        }

        public GarbageDeathable RecoverByCreate(string id)
        {
            GarbageDeathableData data = _worldDataService.WorldData.GarbageDeathableDatas[id];
            return _gameFactory.Create(id, null, data.Vector3Data.ToVector(), Quaternion.identity);
        }

        public void SetToData(GarbageDeathableData garbageDeathableData)
        {
            _worldDataService.WorldData.GarbageDeathableDatas.TryAdd(garbageDeathableData.Id, garbageDeathableData);
        }
    }
}