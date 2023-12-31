﻿using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Architecture.Asset_Loading
{
    public interface IAssetLoader<T>
    {
        string Key { get; }
        object Asset { get; }
        T Load();
        T LoadAndInstantiate(Transform parent);
        Task<T> LoadAndInstantiateAsync(Transform parent);
        Task<T> LoadAsync();
        void Unload();
    }
}