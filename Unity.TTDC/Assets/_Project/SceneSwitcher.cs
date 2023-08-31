using Assets._Project.Architecture.Scene_Switching;
using UnityEngine.AddressableAssets;

namespace Assets._Project
{
    public class SceneSwitcher : ISceneSwitcher
    {
        public async void ChangeAsync(object key)
        {
            await Addressables.LoadSceneAsync("Empty").Task;
            await Addressables.LoadSceneAsync(key).Task;
        }
    }
}
