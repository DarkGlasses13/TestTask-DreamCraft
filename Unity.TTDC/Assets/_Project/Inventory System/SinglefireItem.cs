using System;

namespace Assets._Project.Inventory_System
{
    [Serializable]
    public class SinglefireItem : GunItem
    {
        protected override IAtackStrategy AttackStrategy => throw new System.NotImplementedException();
    }
}
