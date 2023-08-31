using Assets._Project.Architecture.Core;
using System;
using System.Linq;

namespace Assets._Project.Inventory
{
    public class InventoryController : Controller, IInventoryController
    {
        private readonly IItem[] _items;
        private readonly IItemDatabase _database;

        public InventoryController(int capacity, IItemDatabase database)
        {
            _items = new IItem[capacity];
            _database = database;
        }

        public int Capacity => _items.Length;
        public bool HasEmptySlots => _items.Contains(null);
        public int EmptySlotsCount => _items.Where(slot => slot == null).Count();

        public bool TryAdd(IItem item)
        {
            if (_items.Contains(item))
                return false;

            if (HasEmptySlots)
            {
                _items[GetEmptySlot()] = item;
                return true;
            }

            return false;
        }

        public bool TryAdd(string id) => TryAdd(_database.GetByID(id));

        public bool TryAdd(params IItem[] items)
        {
            if (EmptySlotsCount >= items.Length)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    TryAdd(items[i]);
                }

                return true;
            }

            return false;
        }

        public bool TryAdd(params string[] ids) => TryAdd(_database.GetByIDs(ids));

        public bool TryRemove(IItem item)
        {
            IItem itemToRemove = _items.SingleOrDefault(slot => slot == item);

            if (itemToRemove != null)
            {
                int slot = Array.IndexOf(_items, itemToRemove);
                _items[slot] = null;
                return true;
            }

            return false;
        }

        public bool TryRemove(string id) => TryRemove(_database.GetByID(id));

        private int GetEmptySlot()
        {
            // TODO : ускорить, запомнив индекс последнего пустого слота

            return Array.IndexOf(_items, _items.First(slot => slot == null));
        }
    }
}
