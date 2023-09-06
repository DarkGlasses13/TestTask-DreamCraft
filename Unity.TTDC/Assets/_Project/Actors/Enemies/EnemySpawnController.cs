using Assets._Project.Architecture.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._Project.Actors.Enemies
{
    public class EnemySpawnController : Controller
    {
        private readonly EnemyController _enemyController;
        private readonly EnemySpawnConfig _config;
        private readonly Transform _spawnCenter;
        private float _time;

        public EnemySpawnController(EnemyController enemyController, EnemySpawnConfig config, Transform spawnCenter)
        {
            _enemyController = enemyController;
            _config = config;
            _spawnCenter = spawnCenter;
        }

        public override void Tick()
        {
            if (_time == 0)
            {
                Vector2 randomValue = Random.insideUnitCircle.normalized * _config.Distance;
                Vector3 randomPosition = new(_spawnCenter.position.x + randomValue.x, 0, _spawnCenter.position.z + randomValue.y);
                NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, Mathf.Infinity, NavMesh.GetAreaFromName("Not Walkable"));
                _enemyController.Spawn("Simple Enemy", hit.position);
            }

            _time += Time.deltaTime;

            if (_time >= 1 / _config.SpawnRate)
                _time = 0;
        }
    }
}
