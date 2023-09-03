using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class LasergunItem : GunItem
    {
        protected override IItemUseStrategy CreateUseStrategy()
        {
            throw new NotImplementedException();
        }
    }
}
