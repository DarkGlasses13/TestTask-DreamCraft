namespace Assets._Project.Inventory
{
    public interface IInventoryController
    {
        int Capacity { get; }
        bool HasEmptySlots { get; }
        int EmptySlotsCount { get; }
        bool TryAdd(IItem item);
        bool TryAdd(params IItem[] items);
        bool TryRemove(IItem item);
        bool TryAdd(string id);
        bool TryAdd(params string[] ids);
        bool TryRemove(string id);
    }
}
