using UnityEngine;

namespace Assets._Project.Items
{
    [CreateAssetMenu(menuName = "Item/Junk")]
    public class JunkReference : ItemReference
    {
        [SerializeField] private JunkItem _item;

        public override IItem Item => _item;
    }
}
