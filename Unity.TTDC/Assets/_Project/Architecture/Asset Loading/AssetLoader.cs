using System.Threading.Tasks;
using UnityEngine;

public abstract class AssetLoader : IAssetLoader
{
    public object Asset { get; protected set; }

    public abstract T Load<T>(string key);
    public abstract T LoadAndInstantiate<T>(string key, Transform parent) where T : Component;
    public abstract Task<T> LoadAsync<T>(string key);
    public abstract Task<T> LoadAndInstantiateAsync<T>(string key, Transform parent) where T : Component;

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
