using Assets._Project.Architecture.Asset_Loading;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project
{
    public abstract class LocalAssetLoader<T> : AssetLoader<T>
    {
        public override async Task<T> LoadAndInstantiateAsync(Transform parent)
        {
            GameObject instance = await Addressables.InstantiateAsync(Key, parent).Task;

            if (instance.TryGetComponent(out T component))
            {
                Asset = instance;
                return component;
            }

            throw new Exception(
                $"Component of type {typeof(T)} could not be found on {instance.name}");
        }

        public override async Task<T> LoadAsync()
        {
            T asset = await Addressables.LoadAssetAsync<T>(Key).Task;
            Asset = asset;
            return asset;
        }

        public override T LoadAndInstantiate(Transform parent)
        {
            AsyncOperationHandle<GameObject> loadingOperation = Addressables.InstantiateAsync(Key, parent);
            loadingOperation.WaitForCompletion();

            if (loadingOperation.Result.TryGetComponent(out T component))
            {
                Asset = component;
                return component;
            }

            throw new Exception(
                $"Component of type {typeof(T)} could not be found on {loadingOperation.Result.name}");
        }

        public override T Load()
        {
            AsyncOperationHandle<T> loadingOperation = Addressables.LoadAssetAsync<T>(Key);
            loadingOperation.WaitForCompletion();
            return loadingOperation.Result;
        }

        protected override void ReleaseAsset()
        {
            Addressables.Release(Asset);
        }
    }
}
