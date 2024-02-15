using Cysharp.Threading.Tasks;

namespace CodeBase.Services.WorldData
{
    public interface IWorldDataService
    {
        UniTask Load();
        void Save();
        Data.WorldData WorldData { get; }
        void Reset();
    }
}