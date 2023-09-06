using Assets._Project.Architecture.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._Project.Actors.Enemies
{
    public class EnemySpawnController : Controller
    {
        private readonly EnemySpawnConfig _config;
        private readonly EnemyFactory _factory;
        private readonly Transform _spawnCenter;
        private float _time;

        public EnemySpawnController(EnemySpawnConfig config, EnemyFactory factory, Transform spawnCenter)
        {
            _config = config;
            _factory = factory;
            _spawnCenter = spawnCenter;
        }

        public override void Tick()
        {
            if (_time == 0)
            {
                Vector2 randomValue = Random.insideUnitCircle.normalized * _config.Distance;
                Vector3 randomPosition = new(_spawnCenter.position.x + randomValue.x, 0, _spawnCenter.position.z + randomValue.y);
                NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, Mathf.Infinity, NavMesh.GetAreaFromName("Not Walkable"));
                _factory.Create(hit.position);

            }

            _time += Time.deltaTime;

            if (_time >= 1 / _config.SpawnRate)
                _time = 0;
        }
    }
}
