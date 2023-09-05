using Assets._Project.Items.Use_Control;
using Assets._Project.Projectiles;
using UnityEngine;

namespace Assets._Project.Items
{
    public interface IItem
    {
        string ID { get; }
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }
        bool IsEquiped { get; }

        void Equip(IHaveEquipment equipable);
        void Unequip(IHaveEquipment equipable);
        void Drop(IHaveEquipment equipable);
        void Use(ICanUseItem user);
        GameObject GetInstance(Vector3 position, Quaternion rotation, Transform parent);
        void UnloadInstance();
        IItem ConstructAndClone(IItemDatabase database, ProjectileController projectileDealer);
    }
}
