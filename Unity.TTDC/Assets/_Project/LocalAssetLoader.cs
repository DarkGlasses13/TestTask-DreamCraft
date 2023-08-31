using Assets._Project.Architecture.Asset_Loading;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project
{
    public class LocalAssetLoader : AssetLoader
    {
        public override async Task<T> LoadAndInstantiateAsync<T>(string key, Transform parent)
        {
            GameObject instance = await Addressables.InstantiateAsync(key, parent).Task;

            if (instance.TryGetComponent(out T component))
            {
                Asset = instance;
                return component;
            }

            throw new Exception(
                $"Component of type {typeof(T)} could not be found on {instance.name}");
        }

        public override async Task<T> LoadAsync<T>(string key)
        {
            T asset = await Addressables.LoadAssetAsync<T>(key).Task;
            Asset = asset;
            return asset;
        }

        public override T LoadAndInstantiate<T>(string key, Transform parent)
        {
            AsyncOperationHandle<GameObject> loadingOperation = Addressables.InstantiateAsync(key, parent);
            loadingOperation.WaitForCompletion();

            if (loadingOperation.Result.TryGetComponent(out T component))
            {
                Asset = component;
                return component;
            }

            throw new Exception(
                $"Component of type {typeof(T)} could not be found on {loadingOperation.Result.name}");
        }

        public override T Load<T>(string key)
        {
            AsyncOperationHandle<T> loadingOperation = Addressables.LoadAssetAsync<T>(key);
            loadingOperation.WaitForCompletion();
            return loadingOperation.Result;
        }

        protected override void ReleaseAsset()
        {
            Addressables.Release(Asset);
        }
    }
}
