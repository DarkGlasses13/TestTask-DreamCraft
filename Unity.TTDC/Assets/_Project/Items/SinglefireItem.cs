using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class SinglefireItem : GunItem
    {
        protected override IAtackStrategy AttackStrategy => throw new System.NotImplementedException();
    }
}
