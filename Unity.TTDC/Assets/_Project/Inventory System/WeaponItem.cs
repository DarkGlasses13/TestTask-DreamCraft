﻿using UnityEngine;

namespace Assets._Project.Inventory_System
{
    public abstract class WeaponItem : Item
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Distance { get; private set; }
        protected abstract IAtackStrategy AttackStrategy { get; }

        protected override void OnEquip(ICanEquip equipable)
        {
            base.OnEquip(equipable);
            GetInstance(equipable.Hand.position, equipable.Hand.rotation, equipable.Hand);
        }

        protected override void OnUnequip(ICanEquip equipable)
        {
            base.OnUnequip(equipable);
            UnloadInstance();

        }

        public override void Use(ICanUseItem user)
        {
            base.Use(user);
            AttackStrategy?.Attack(user);
        }
    }
}