using UnityEngine;

namespace Assets._Project.Inventory_System
{
    public abstract class ItemReference : ScriptableObject
    {
        public abstract IItem Item { get; }
    }
}
