using UnityEngine;

namespace Assets._Project.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon/Singlefire")]
    public class SinglefireReference : ItemReference
    {
        [SerializeField] private SinglefireItem _item; 
        public override IItem Item => _item;
    }
}
