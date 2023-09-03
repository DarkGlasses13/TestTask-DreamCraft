using System.Threading.Tasks;

namespace Assets._Project.Items
{
    public interface IItemDatabase
    {
        Task LoadItemsAsync();
        IItem GetByID(string id);
        IItem[] GetByIDs(params string[] ids);
    }
}
