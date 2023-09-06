using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Assets._Project.Architecture.Core;
using System.Collections.Generic;
using System.Linq;
using Assets._Project.Health_Control;
using Assets._Project.Items;

namespace Assets._Project.Projectiles
{
    public class ProjectileController : Controller
    {
        private List<Projectile> _projectiles = new();

        public Projectile Create(GunItem gun, Vector3 position, Quaternion rotation)
        {
            Projectile projectile = _projectiles.FirstOrDefault(projectile
                => projectile.ID == gun.ProjectileKey
                && projectile.gameObject.activeSelf == false);

            if (projectile == null)
            {
                AsyncOperationHandle<GameObject> instantiate = Addressables
                .InstantiateAsync(gun.ProjectileKey);
                instantiate.WaitForCompletion();
                projectile = instantiate.Result.GetComponent<Projectile>();
                projectile.Construct(gun);
                projectile.OnHit += OnHit;
                _projectiles.Add(projectile);
            }
            else
            {
                projectile.Trail.Clear();
                projectile.gameObject.SetActive(true);
            }

            projectile.transform.SetPositionAndRotation(position, rotation);
            return projectile;
        }

        private void OnHit(Projectile projectile, IHaveHealth entity)
        {
            entity?.TakeDamage(projectile.Damage);
        }
    }
}
