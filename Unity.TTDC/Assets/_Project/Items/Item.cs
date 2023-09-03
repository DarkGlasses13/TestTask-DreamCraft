using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project.Items
{
    public abstract class Item : IItem
    {
        protected GameObject _instance;
        private IItemUseStrategy _useStrategy;

        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, TextArea] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        public bool IsEquiped { get; private set; }

        public GameObject GetInstance(Vector3 position, Quaternion rotation, Transform parent)
        {
            //if (_instance != null)
            //    UnloadInstance();

            if (_instance != null)
                return _instance;

            AsyncOperationHandle<GameObject> loading = Addressables.InstantiateAsync(ID, position, rotation, parent);
            loading.WaitForCompletion();
            _instance = loading.Result;
            OnInstanceLoaded();
            return _instance;
        }

        protected virtual void OnInstanceLoaded()
        {
            _useStrategy ??= CreateUseStrategy();
            _instance
                .AddComponent<ItemInstance>()
                .Construct(ID);
        }

        protected abstract IItemUseStrategy CreateUseStrategy();

        public void Drop(IHaveEquipment equipable) { }

        public void Equip(IHaveEquipment equipable)
        {
            if (equipable == null)
                return;

            if (IsEquiped)
                return;

            IsEquiped = true;
            OnEquip(equipable);
        }

        protected virtual void OnEquip(IHaveEquipment equipable) { }

        public void Unequip(IHaveEquipment equipable) 
        {
            if (equipable == null)
                return;

            if (IsEquiped == false)
                return;

            IsEquiped = false;
            OnUnequip(equipable);
        }

        protected virtual void OnUnequip(IHaveEquipment equipable) { }

        public virtual void StartUse(ICanUseItem user) => _useStrategy?.Start(user);

        public virtual void Use(ICanUseItem user) => _useStrategy?.Update(user);

        public virtual void FixedUse(ICanUseItem user) => _useStrategy?.FixedUpdate(user);

        public virtual void StopUse(ICanUseItem user) => _useStrategy?.Stop(user);

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
