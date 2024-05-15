using System;
using CodeBase.Enums;
using UnityEngine;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    [Serializable]
    public class GarbageOptionInfo
    {
        public Sprite Icon;
        public string Name;
        public GarbageType GarbageType;
        public string Description;
        public int DangerRate;
    }
}