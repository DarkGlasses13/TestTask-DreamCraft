using System;

namespace Assets._Project.Inventory_System
{
    [Serializable]
    public class LasergunItem : GunItem
    {
        protected override IAtackStrategy AttackStrategy => throw new System.NotImplementedException();
    }
}
