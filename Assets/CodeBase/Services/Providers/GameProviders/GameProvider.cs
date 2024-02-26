using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using CodeBase.Gameplay.CameraPans;
using CodeBase.Gameplay.Tutorial;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace CodeBase.Services.Providers.GameProviders
{
    public class GameProvider : SerializedMonoBehaviour
    {
        public Terrain Terrain;
        [OdinSerialize] public Dictionary<CameraPanType, CameraPan> CameraPans;

        [OdinSerialize] public List<ITutoriable> Tutoriables;

        [OdinSerialize] public Dictionary<GarbageSpawnZoneType, ITutoriable> GarbageTutoriables;

        private IReadOnlyDictionary<Type, ITutoriable> FiltredTutoriables => 
            Tutoriables.ToDictionary(x => x.GetType(), x => x);

        public ITutoriable GetGarbageSpawnZoneTutoriable(GarbageSpawnZoneType garbageSpawnZoneType)
        {
            return GarbageTutoriables[garbageSpawnZoneType];
        }

        public ITutoriable GetTutoriable<T>() where T : ITutoriable
        {
            return FiltredTutoriables[typeof(T)];
        }

    }
}