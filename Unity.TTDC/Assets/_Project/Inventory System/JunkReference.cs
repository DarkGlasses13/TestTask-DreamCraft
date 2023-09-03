using UnityEngine;

namespace Assets._Project.Inventory_System
{
    [CreateAssetMenu(menuName = "Item/Junk")]
    public class JunkReference : ItemReference
    {
        [SerializeField] private JunkItem _item;

        public override IItem Item => _item;
    }
}
