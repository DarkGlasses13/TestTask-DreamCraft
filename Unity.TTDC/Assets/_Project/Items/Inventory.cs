using System;
using System.Linq;

namespace Assets._Project.Items
{
    public class Inventory : IInventory
    {
        public event Action OnChanged;

        private readonly IItem[] _items;

        public Inventory(int capacity)
        {
            _items = new IItem[capacity];
        }

        public int Capacity => _items.Length;
        public bool HasEmptySlots => _items.Contains(null);
        public int EmptySlotsCount => _items.Where(slot => slot == null).Count();

        public IItem Get(int selected) => _items[selected];

        public bool TryAdd(IItem item)
        {
            if (_items.Contains(item))
                return false;

            if (HasEmptySlots)
            {
                _items[GetEmptySlot()] = item;
                OnChanged?.Invoke();
                return true;
            }

            return false;
        }

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

        public bool TryRemove(IItem item)
        {
            IItem itemToRemove = _items.SingleOrDefault(slot => slot == item);

            if (itemToRemove != null)
            {
                int slot = Array.IndexOf(_items, itemToRemove);
                _items[slot] = null;
                OnChanged?.Invoke();
                return true;
            }

            return false;
        }

        private int GetEmptySlot()
        {
            // TODO : ускорить, запомнив индекс последнего пустого слота

            return Array.IndexOf(_items, _items.First(slot => slot == null));
        }
    }
}
