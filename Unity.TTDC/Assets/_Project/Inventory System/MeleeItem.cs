using System;

namespace Assets._Project.Inventory_System
{
    [Serializable]
    public class MeleeItem : WeaponItem
    {
        protected override IAtackStrategy AttackStrategy => throw new System.NotImplementedException();
    }
}
