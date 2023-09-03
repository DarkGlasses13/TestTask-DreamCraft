using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class ShotgunItem : GunItem
    {
        protected override IItemUseStrategy CreateUseStrategy() => new ShotgunAttackStrategy(this);
    }
}
