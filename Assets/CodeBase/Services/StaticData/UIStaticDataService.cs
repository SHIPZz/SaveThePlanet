using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.UI.Effects;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class UIStaticDataService
    {
        private readonly Dictionary<EffectType, Effect> _effects;
        private readonly Dictionary<Type, WindowBase> _windows;

        public UIStaticDataService()
        {
            _effects = Resources.LoadAll<Effect>(AssetPath.Effects)
                .ToDictionary(x => x.EffectType, x => x);

            _windows = Resources.LoadAll<WindowBase>(AssetPath.Windows)
                .ToDictionary(x => x.GetType(), x => x);
        }

        public T Get<T>() where T : WindowBase => 
            (T)_windows[typeof(T)];

        public Effect Get(EffectType effectType)
        {
            return _effects[effectType];
        }
    }
}