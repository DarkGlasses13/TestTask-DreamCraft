using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project.Actors.Enemies
{
    public class EnemyFactory
    {
        private Transform _container;

        public EnemyFactory(Transform container)
        {
            _container = container;
        }

        public Enemy Create(Vector3 position)
        {
            AsyncOperationHandle<GameObject> instantiate = Addressables.InstantiateAsync("Simple Enemy", position, Quaternion.identity);
            instantiate.WaitForCompletion();
            return instantiate.Result.GetComponent<Enemy>();
        }
    }
}
