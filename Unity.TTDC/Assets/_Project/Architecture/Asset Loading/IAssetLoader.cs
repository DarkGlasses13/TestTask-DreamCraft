using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Architecture.Asset_Loading
{
    public interface IAssetLoader
    {
        object Asset { get; }
        T Load<T>(string key);
        T LoadAndInstantiate<T>(string key, Transform parent) where T : Component;
        Task<T> LoadAndInstantiateAsync<T>(string key, Transform parent) where T : Component;
        Task<T> LoadAsync<T>(string key);
        void Unload();
    }
}