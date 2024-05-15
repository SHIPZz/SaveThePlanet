using System;
using System.Collections.Generic;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    [Serializable]
    public class GarbageMinigameData
    {
        public List<GarbageOptionInfo> GarbageOptionInfos = new();
        public List<GarbageAnswerData> garbageAnswerDatas = new();
    }
}