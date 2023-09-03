using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class MeleeItem : WeaponItem
    {
        protected override IItemUseStrategy CreateUseStrategy() => new MeleeAttackStrategy(this);
    }
}
