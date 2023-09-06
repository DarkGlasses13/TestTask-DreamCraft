using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Assets._Project.Architecture.Core;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Projectiles
{
    public class ProjectileController : Controller
    {
        private string _key;
        private List<Projectile> _projectiles = new();

        public Projectile Create(string key, Vector3 position, Quaternion rotation)
        {
            _key = key;
            Projectile projectile = Get(key);
            projectile.transform.SetPositionAndRotation(position, rotation);
            return projectile;
        }

        private Projectile Get(string key)
        {
            Projectile projectile = _projectiles.FirstOrDefault(projectile 
                => projectile.ID == key 
                && projectile.gameObject.activeSelf == false);

            if (projectile == null)
            {
                AsyncOperationHandle<GameObject> instantiate = Addressables
                .InstantiateAsync(_key);
                instantiate.WaitForCompletion();
                projectile = instantiate.Result.GetComponent<Projectile>();
                projectile.Construct(_key);
            }
            else
            {
                projectile.Trail.Clear();
                projectile.gameObject.SetActive(true);
            }

            _projectiles.Add(projectile);
            return projectile;
        }
    }
}
