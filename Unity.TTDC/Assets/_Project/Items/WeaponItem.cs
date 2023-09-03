using UnityEngine;

namespace Assets._Project.Items
{
    public abstract class WeaponItem : Item
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Distance { get; private set; }

        protected override void OnEquip(IHaveEquipment equipable)
        {
            base.OnEquip(equipable);
            GetInstance(equipable.Hand.position, equipable.Hand.rotation, equipable.Hand);
        }

        protected override void OnUnequip(IHaveEquipment equipable)
        {
            base.OnUnequip(equipable);
            UnloadInstance();

        }
    }
}
