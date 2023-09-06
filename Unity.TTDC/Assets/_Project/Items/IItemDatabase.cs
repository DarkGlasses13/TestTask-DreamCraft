using UnityEngine;

namespace Assets._Project.Items
{
    public interface IItemDatabase
    {
        IItem GetByID(string id);
        IItem[] GetByIDs(params string[] ids);
        void OnInstanceUnloaded(IItem item);
    }
}
