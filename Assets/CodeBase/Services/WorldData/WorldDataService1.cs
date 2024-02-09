using CodeBase.Services.SaveSystem;
using Cysharp.Threading.Tasks;

namespace CodeBase.Services
{
    public class WorldDataService : IWorldDataService
    {
        private readonly ISaveSystem _saveSystem;
        
        public Data.WorldData WorldData { get; private set; }

        public WorldDataService(ISaveSystem saveSystem) => 
            _saveSystem = saveSystem;

        public async UniTask Load()
        {
            WorldData = await _saveSystem.Load();
        }

        public void Reset()
        {
            WorldData = null;
            WorldData = new();
            Save();
        }

        public void Save() => 
            _saveSystem.Save(WorldData);
    }
}