using UnityEngine;

namespace Assets._Project.Items
{
    public abstract class ItemReference : ScriptableObject
    {
        public abstract IItem Item { get; }
    }
}
