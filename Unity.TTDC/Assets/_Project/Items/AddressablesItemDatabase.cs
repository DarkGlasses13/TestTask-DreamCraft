using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Assets._Project.Items
{
    public class AddressablesItemDatabase : ItemDatabase
    {
        private readonly object _label;

        public AddressablesItemDatabase(object label)
        {
            _label = label;
        }

        public override async Task LoadItemsAsync()
        {
            IList<ItemReference> loadedItems = await Addressables.LoadAssetsAsync<ItemReference>(_label, null).Task;
            _references = loadedItems.ToArray();
        }
    }
}
