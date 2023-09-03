using UnityEngine;

namespace Assets._Project.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon/Shotgun")]
    public class ShotgunReference : ItemReference
    {
        [SerializeField] private ShotgunItem _item; 
        public override IItem Item => _item;
    }
}
