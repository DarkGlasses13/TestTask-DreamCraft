using UnityEngine;

namespace Assets._Project.Items
{
    public class ItemEquiper
    {
        private readonly IInventory _inventory;
        private readonly ICanEquip _equipable;
        private int _selected;

        public ItemEquiper(int selected, IInventory inventory, ICanEquip equipable)
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
                _inventory.Get(_selected)?.Equip(_equipable);
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
            _inventory.Get(_selected)?.Equip(_equipable);
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
