﻿using UnityEngine;
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

        public Enemy Create(string key, Vector3 position)
        {
            AsyncOperationHandle<GameObject> instantiate = Addressables.InstantiateAsync(key, position, Quaternion.identity, _container);
            instantiate.WaitForCompletion();
            Enemy enemy = instantiate.Result.GetComponent<Enemy>();
            enemy.Construct(key);
            return enemy;
        }
    }
}
