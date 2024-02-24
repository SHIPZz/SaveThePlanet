using System;
using System.Collections.Generic;
using CodeBase.Enums;

namespace CodeBase.Data
{
    [Serializable]
    public class TutorialData
    {
        public Dictionary<TutorialType, bool> CompletedTutorials = new();
        public Dictionary<WarningItemType, bool> ShownWarnings = new();
    }
}