using Cysharp.Threading.Tasks;

namespace CodeBase.Services.SaveSystem
{
    public interface ISaveSystem
    {
        void Save(Data.WorldData data);

        UniTask<Data.WorldData> Load();
    }
}