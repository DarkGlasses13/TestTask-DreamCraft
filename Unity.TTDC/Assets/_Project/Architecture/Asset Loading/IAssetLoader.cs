using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Architecture.Asset_Loading
{
    public interface IAssetLoader<T>
    {
        string Key { get; }
        object Asset { get; }
        T Load();
        T LoadAndInstantiate<C>(Transform parent) where C : Component;
        Task<T> LoadAndInstantiateAsync<C>(Transform parent) where C : Component;
        Task<T> LoadAsync();
        void Unload();
    }
}