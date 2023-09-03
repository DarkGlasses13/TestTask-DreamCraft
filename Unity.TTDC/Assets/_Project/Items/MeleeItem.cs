using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class MeleeItem : WeaponItem
    {
        protected override IAtackStrategy AttackStrategy => throw new System.NotImplementedException();
    }
}
