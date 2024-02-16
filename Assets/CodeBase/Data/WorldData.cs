using System;
using System.Collections.Generic;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public Dictionary<string, GarbageDeathableData> GarbageDeathableDatas = new();
    }
}