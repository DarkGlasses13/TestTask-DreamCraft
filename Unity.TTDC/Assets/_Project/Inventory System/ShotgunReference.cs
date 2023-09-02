using UnityEngine;

namespace Assets._Project.Inventory_System
{
    [CreateAssetMenu(menuName = "Item/Weapon/Shotgun")]
    public class ShotgunReference : ItemReference
    {
        [SerializeField] private ShotgunItem _item; 
        public override IItem Item => _item;
    }
}
