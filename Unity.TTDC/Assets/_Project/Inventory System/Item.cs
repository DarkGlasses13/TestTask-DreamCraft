using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project.Inventory_System
{
    public abstract class Item : IItem
    {
        private 
        protected GameObject _instance;
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, TextArea] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        public GameObject GetInstance(Vector3 position, Quaternion rotation, Transform parent)
        {
            AsyncOperationHandle<GameObject> loading = Addressables.InstantiateAsync(ID, position, rotation, parent);
            loading.WaitForCompletion();
            _instance = loading.Result;
            OnInstanceLoaded();
            return _instance;
        }

        protected virtual void OnInstanceLoaded()
        {
            _instance
                .AddComponent<ItemInstance>()
                .Construct(ID);
        }

        public virtual void Drop(ICanEquip equipable) {}
        public virtual void Equip(ICanEquip equipable) {}
        public virtual void Unequip(ICanEquip equipable) {}
        public virtual void Use(ICanUseItem user) {}

        public void UnloadInstance()
        {
            if (_instance)
            {
                _instance.SetActive(false);
                _instance.transform.SetParent(null);
                Addressables.ReleaseInstance(_instance);
                _instance = null;
            }
        }

        public object Clone() => MemberwiseClone();
    }
}
