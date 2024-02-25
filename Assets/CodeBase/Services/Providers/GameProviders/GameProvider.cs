using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.Gameplay.CameraPans;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace CodeBase.Services.Providers.GameProviders
{
    public class GameProvider : SerializedMonoBehaviour
    {
        public Terrain Terrain;
        [OdinSerialize] public Dictionary<CameraPanType, CameraPan> CameraPans;

    }
}