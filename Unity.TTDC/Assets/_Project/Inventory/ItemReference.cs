using UnityEngine;

namespace Assets._Project.Inventory
{
    [CreateAssetMenu(menuName = "Item")]
    public class ItemReference : ScriptableObject, IItem
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
    }
}
