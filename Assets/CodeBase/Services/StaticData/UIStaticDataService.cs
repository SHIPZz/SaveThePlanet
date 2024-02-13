using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.UI.Effects;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class UIStaticDataService
    {
        private readonly Dictionary<EffectType, Effect> _effects;

        public UIStaticDataService()
        {
            _effects = Resources.LoadAll<Effect>(AssetPath.Effects)
                .ToDictionary(x => x.EffectType, x => x);
        }

        public Effect Get(EffectType effectType)
        {
            return _effects[effectType];
        }
    }
}