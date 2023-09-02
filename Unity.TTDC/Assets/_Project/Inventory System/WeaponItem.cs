using UnityEngine;

namespace Assets._Project.Inventory_System
{
    public abstract class WeaponItem : Item
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Distance { get; private set; }
        protected abstract IAtackStrategy AttackStrategy { get; }

        public override void Equip(ICanEquip equipable)
        {
            if (equipable == null)
                return;

            base.Equip(equipable);
            GetInstance(equipable.Hand.position, equipable.Hand.rotation, equipable.Hand);
        }

        public override void Unequip(ICanEquip equipable)
        {
            base.Unequip(equipable);
            UnloadInstance();
        }

        public override void Use(ICanUseItem user)
        {
            base.Use(user);
            AttackStrategy?.Attack(user);
        }
    }
}
