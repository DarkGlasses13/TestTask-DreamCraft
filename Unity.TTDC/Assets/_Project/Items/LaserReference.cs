using UnityEngine;

namespace Assets._Project.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon/Lasergun")]
    public class LaserReference : ItemReference
    {
        [SerializeField] private LasergunItem _item; 
        public override IItem Item => _item;
    }
}
