using UnityEngine;

namespace Assets._Project.Inventory_System
{
    [CreateAssetMenu(menuName = "Item/Weapon/Melee")]
    public class MeleeReference : ItemReference
    {
        [SerializeField] private MeleeItem _item;

        public override IItem Item => _item;
    }
}
