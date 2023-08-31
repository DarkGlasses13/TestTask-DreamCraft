using System.Linq;
using UnityEngine;

namespace Assets._Project.Inventory
{
    [CreateAssetMenu(menuName = "Item Database")]
    public class ItemDatabase : ScriptableObject, IItemDatabase
    {
        [SerializeField] private ItemReference[] _items;

        public IItem GetByID(string id)
        {
            return _items.SingleOrDefault(itm => itm.ID == id);
        }

        IItem[] IItemDatabase.GetByIDs(params string[] ids)
        {
            IItem[] items = new IItem[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                items[i] = GetByID(ids[i]);
            }

            return items;
        }
    }
}
