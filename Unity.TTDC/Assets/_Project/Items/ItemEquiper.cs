using UnityEngine;

namespace Assets._Project.Items
{
    public class ItemEquiper : IItemEquiper
    {
        private readonly IInventory _inventory;
        private readonly IHaveEquipment _equipable;
        private int _selected;

        public IItem Selected { get; private set; }

        public ItemEquiper(int selected, IInventory inventory, IHaveEquipment equipable)
        {
            _inventory = inventory;
            _equipable = equipable;
            _selected = GetClamped(selected);
            _inventory.OnChanged += OnInventoryChanged;
        }

        private void OnInventoryChanged() => Swap();

        public void Swap(float value = 0)
        {
            if (value == 0)
            {
                EquipSelected();
                return;
            }

            int previousIndex = _selected;

            if (value > 0)
                _selected++;

            if (value < 0)
                _selected--;

            _selected = GetClamped(_selected);

            if (_selected == previousIndex)
                return;

            _inventory.Get(previousIndex)?.Unequip(_equipable);
            EquipSelected();
        }

        private void EquipSelected()
        {
            Selected = _inventory.Get(_selected);
            Selected?.Equip(_equipable);
        }

        private int GetClamped(int value)
        {
            return Mathf.Clamp(value, 0, _inventory.Capacity - 1);
        }

        ~ItemEquiper()
        {
            _inventory.OnChanged -= OnInventoryChanged;
        }
    }
}
