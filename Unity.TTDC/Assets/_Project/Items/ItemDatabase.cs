using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assets._Project.Items
{
    public abstract class ItemDatabase : IItemDatabase
    {
        protected ItemReference[] _references;
        protected readonly List<IItem> _items = new();

        public abstract Task LoadItemsAsync();

        public IItem GetByID(string id)
        {
            IItem item = (IItem)_references
                .SingleOrDefault(reference => reference.Item.ID == id).Item
                .Clone();

            _items.Add(item);
            return item;
        }

        public IItem[] GetByIDs(params string[] ids)
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
