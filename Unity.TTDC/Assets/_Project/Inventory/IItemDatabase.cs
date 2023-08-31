namespace Assets._Project.Inventory
{
    public interface IItemDatabase
    {
        IItem GetByID(string id);
        IItem[] GetByIDs(params string[] ids);
    }
}
