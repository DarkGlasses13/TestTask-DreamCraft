using UnityEngine;

namespace Assets._Project.Actors.Enemies
{
    [CreateAssetMenu(menuName = "Config/Enemy Spawn Config")] 
    public class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnRate { get; private set; }
        [field: SerializeField] public float Distance { get; private set; }
    }
}
