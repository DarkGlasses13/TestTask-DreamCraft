using UnityEngine;

namespace Assets._Project.Inventory_System
{
    [CreateAssetMenu(menuName = "Item/Weapon/Singlefire")]
    public class SinglefireReference : ItemReference
    {
        [SerializeField] private SinglefireItem _item; 
        public override IItem Item => _item;
    }
}
