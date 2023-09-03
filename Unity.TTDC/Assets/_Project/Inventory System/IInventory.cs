using System;

namespace Assets._Project.Inventory_System
{
    public interface IInventory
    {
        event Action OnChanged;

        int Capacity { get; }
        bool HasEmptySlots { get; }
        int EmptySlotsCount { get; }

        bool TryAdd(params IItem[] items);
        bool TryRemove(IItem item);
        bool TryAdd(string id);
        bool TryAdd(params string[] ids);
        bool TryRemove(string id);
        IItem Get(int selected);
    }
}
