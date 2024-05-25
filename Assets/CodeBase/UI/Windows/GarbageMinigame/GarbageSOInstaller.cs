using UnityEngine;
using Zenject;

namespace CodeBase.UI.Windows.GarbageMinigame
{
    [CreateAssetMenu(fileName = nameof(GarbageSOInstaller), menuName = "Gameplay/Data/GarbageSOInstaller")]
    public class GarbageSOInstaller : ScriptableObjectInstaller
    {
        public GarbageMiniGameSO GarbageMiniGameSo;
        
        public override void InstallBindings()
        {
            Container.BindInstance(GarbageMiniGameSo);
        }
    }
}