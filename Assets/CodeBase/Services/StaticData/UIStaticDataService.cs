using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using CodeBase.Enums;
using CodeBase.Gameplay.Tutorial;
using CodeBase.ScriptableObjects.Tutorial;
using CodeBase.ScriptableObjects.WarningItems;
using CodeBase.UI.Effects;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class UIStaticDataService
    {
        private readonly Dictionary<EffectType, Effect> _effects;
        private readonly Dictionary<Type, WindowBase> _windows;
        private readonly Dictionary<WarningItemType, WarningItemSO> _warningItemDatas;
        private readonly Dictionary<TutorialType, AbstractTutorialStep> _tutorials;

        public UIStaticDataService()
        {
            _effects = Resources.LoadAll<Effect>(AssetPath.Effects)
                .ToDictionary(x => x.EffectType, x => x);

            _windows = Resources.LoadAll<WindowBase>(AssetPath.Windows)
                .ToDictionary(x => x.GetType(), x => x);
            
            _warningItemDatas = Resources.LoadAll<WarningItemSO>(AssetPath.WarningItemDatas)
                .ToDictionary(x=>x.WarningItemType, x => x);

            _tutorials = Resources.LoadAll<AbstractTutorialStep>(AssetPath.Tutorials)
                .ToDictionary(x => x.TutorialType, x => x);
        }

        public AbstractTutorialStep GetTutorialStep(TutorialType tutorialType)
        {
            return _tutorials[tutorialType];
        }

        public WarningItemSO Get(WarningItemType warningItemType)
        {
            return _warningItemDatas[warningItemType];
        }

        public T Get<T>() where T : WindowBase => 
            (T)_windows[typeof(T)];

        public Effect Get(EffectType effectType)
        {
            return _effects[effectType];
        }
    }
}