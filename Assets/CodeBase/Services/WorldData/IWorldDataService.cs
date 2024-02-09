using CodeBase.Data;
using Cysharp.Threading.Tasks;

namespace CodeBase.Services
{
    public interface IWorldDataService
    {
        UniTask Load();
        void Save();
        WorldData WorldData { get; }
        void Reset();
    }
}