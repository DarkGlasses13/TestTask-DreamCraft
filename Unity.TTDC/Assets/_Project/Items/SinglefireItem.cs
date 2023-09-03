using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class SinglefireItem : GunItem
    {
        protected override IItemUseStrategy CreateUseStrategy() => new SinglefireAttackStrategy(this);
    }
}
