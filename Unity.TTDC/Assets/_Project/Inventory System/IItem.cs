using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Inventory_System
{
    public interface IItem : ICloneable
    {
        string ID { get; }
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }

        void Equip(ICanEquip equipable);
        void Unequip(ICanEquip equipable);
        void Drop(ICanEquip equipable);
        void Use(ICanUseItem user);
        GameObject GetInstance(Vector3 position, Quaternion rotation, Transform parent);
        void UnloadInstance();
    }
}
