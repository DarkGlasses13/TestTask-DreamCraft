using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Architecture.Asset_Loading
{
    public abstract class AssetLoader<T> : IAssetLoader<T>
    {
        public abstract string Key { get; }
        public object Asset { get; protected set; }

        public abstract T Load();
        public abstract T LoadAndInstantiate<C>(Transform parent) where C : Component;
        public abstract Task<T> LoadAndInstantiateAsync<C>(Transform parent) where C : Component;
        public abstract Task<T> LoadAsync();

        public void Unload()
        {
            if (Asset != null)
            {
                if (Asset is GameObject asset)
                {
                    asset.SetActive(false);
                }

                ReleaseAsset();
                Asset = null;
            }
        }

        protected abstract void ReleaseAsset();
    }
}