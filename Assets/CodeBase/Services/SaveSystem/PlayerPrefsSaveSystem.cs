using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Services.SaveSystem
{
    public class PlayerPrefsSaveSystem : ISaveSystem
    {
        private const string DataKey = "Data";
        
        public void Save(Data.WorldData data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            
            PlayerPrefs.SetString(DataKey, jsonData);
            PlayerPrefs.Save();
        }
        
        public async UniTask<Data.WorldData> Load()
        {
            if (PlayerPrefs.HasKey(DataKey))
            {
                string jsonData = PlayerPrefs.GetString(DataKey);
                return JsonConvert.DeserializeObject<Data.WorldData>(jsonData);
            }
            
            await UniTask.Yield();
            
            return new Data.WorldData();
        }
    }
}