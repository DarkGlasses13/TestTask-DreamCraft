using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Items
{
    public class ItemDatabase : IItemDatabase
    {
        private readonly ItemFactory _factory;
        private readonly ItemReference[] _references;
        private readonly List<IItem> _items = new();

        public ItemDatabase(ItemFactory factory, ItemReference[] references)
        {
            _factory = factory;
            _references = references;
        }

        public IItem GetByID(string id)
        {
            ItemReference reference = _references
                .SingleOrDefault(reference => reference.Item.ID == id);

            IItem item = _factory.Create(this, reference);
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

        public void OnInstanceUnloaded(IItem item) => _items.Remove(item);
    }
}
