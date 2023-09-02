using System.Threading.Tasks;

namespace Assets._Project.Inventory_System
{
    public interface IItemDatabase
    {
        Task LoadItemsAsync();
        IItem GetByID(string id);
        IItem[] GetByIDs(params string[] ids);
    }
}
