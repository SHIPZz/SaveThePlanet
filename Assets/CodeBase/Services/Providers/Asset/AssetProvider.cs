using UnityEngine;

namespace CodeBase.Services.Providers.Asset
{
    public class AssetProvider : IAssetProvider
    {
        public T Get<T>(string path) where T : Component
        {
            var prefab = Resources.Load<T>(path);
            return prefab;
        }
    }
}