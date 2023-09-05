using System;

namespace Assets._Project.Items
{
    public interface IInventory
    {
        event Action OnChanged;

        int Capacity { get; }
        bool HasEmptySlots { get; }
        int EmptySlotsCount { get; }

        bool TryAdd(params IItem[] items);
        bool TryRemove(IItem item);
        bool TryAdd(IItem item);
        IItem Get(int selected);
    }
}
