using Assets._Project.Architecture.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Actors.Enemies
{
    public class EnemyController : Controller
    {
        private readonly List<Enemy> _enemies = new();
        private readonly Transform _target;

        public EnemyController(Transform target)
        {
            _target = target;
        }

        public Enemy Spawn(Vector3 position)
        {
            return null;
        }

        public override void Tick()
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.gameObject.activeSelf)
                {
                    enemy.Move(_target.position);

                    if (enemy.IsReachedTarget)
                    {

                    }

                }
            }
        }
    }
}
