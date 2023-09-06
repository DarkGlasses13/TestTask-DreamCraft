using Assets._Project.Items.Use_Control;
using Assets._Project.Projectiles;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets._Project.Items
{
    public abstract class Item : IItem
    {
        private GameObject _instance;
        private IItemDatabase _database;
        protected ProjectileController _projectileController;

        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField, TextArea] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        public bool IsEquiped { get; private set; }

        public GameObject GetInstance()
        {
            //if (_instance != null)
            //    UnloadInstance();

            if (_instance != null)
                return _instance;

            AsyncOperationHandle<GameObject> loading = Addressables.InstantiateAsync(ID);
            loading.WaitForCompletion();
            _instance = loading.Result;
            OnInstanceLoaded(_instance);
            return _instance;
        }

        public GameObject GetInstance(Vector3 position, Quaternion rotation, Transform parent)
        {
            GetInstance();
            _instance.transform.SetLocalPositionAndRotation(position, rotation);
            _instance.transform.SetParent(parent);
            return _instance;
        }

        protected virtual void OnInstanceLoaded(GameObject instance)
        {
            instance
                .GetComponent<ItemInstance>()
                .Construct(ID);
        }

        public void Equip(IHaveEquipment equipable)
        {
            if (equipable == null)
                return;

            if (IsEquiped)
                return;

            IsEquiped = true;
            OnEquip(equipable);
        }

        public void Unequip(IHaveEquipment equipable)
        {
            if (equipable == null)
                return;

            if (IsEquiped == false)
                return;

            IsEquiped = false;
            OnUnequip(equipable);
        }

        public void Drop(IHaveEquipment equipable) { }

        protected virtual void OnEquip(IHaveEquipment equipable) { }

        protected virtual void OnUnequip(IHaveEquipment equipable) { }

        public virtual void StartUse(ICanUseItem user) { }

        public virtual void Use(ICanUseItem user) { }

        public virtual void StopUse(ICanUseItem user) { }

        public void UnloadInstance()
        {
            if (_instance)
            {
                _instance.SetActive(false);
                _instance.transform.SetParent(null);
                Addressables.ReleaseInstance(_instance);
                _database.OnInstanceUnloaded(this);
                _instance = null;
            }
        }

        public IItem ConstructAndClone(IItemDatabase database, ProjectileController projectileController)
        {
            _database = database;
            _projectileController = projectileController;
            return (IItem)MemberwiseClone();
        }
    }
}
