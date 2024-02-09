﻿using UnityEngine;

namespace CodeBase.Services.Providers.Asset
{
    public interface IAssetProvider
    {
        T Get<T>(string path) where T : Component;
    }
}