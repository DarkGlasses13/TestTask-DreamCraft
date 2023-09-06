using Assets._Project.Architecture.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Actors.Enemies
{
    public class EnemyController : Controller
    {
        private readonly List<Enemy> _enemies = new();
        private readonly Transform _target;
        private readonly EnemyFactory _factory;

        public EnemyController(Transform target, EnemyFactory factory)
        {
            _target = target;
            _factory = factory;
        }

        public Enemy Spawn(string key, Vector3 position)
        {
            Enemy enemy = _enemies.FirstOrDefault(enemy
                => enemy.ID == key
                && enemy.isActiveAndEnabled == false);

            if (enemy == null)
            {
                enemy = _factory.Create(key, position);
                _enemies.Add(enemy);
            }
            else
            {
                enemy.gameObject.SetActive(true);
            }

            enemy.transform.position = position;
            return enemy;
        }

        public override void Tick()
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.isActiveAndEnabled)
                {
                    enemy.MoveTo(_target.position);
                }
            }
        }
    }

}
