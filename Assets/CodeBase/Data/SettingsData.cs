using System;
using System.Collections.Generic;
using CodeBase.Enums;

namespace CodeBase.Data
{
    [Serializable]
    public class SettingsData
    {
        public Dictionary<MixerTypeId, bool> Sounds = new()
        {
            { MixerTypeId.Music, true },
            { MixerTypeId.UI, true }
        };
    }
}