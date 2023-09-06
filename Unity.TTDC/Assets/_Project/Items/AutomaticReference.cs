using UnityEngine;

namespace Assets._Project.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon/Automatic")]
    public class AutomaticReference : ItemReference
    {
        [SerializeField] private AutomaticItem _item;
        public override IItem Item => _item;
    }
}
