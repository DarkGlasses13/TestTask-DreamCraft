using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class ShotgunItem : GunItem
    {
        protected override IAtackStrategy AttackStrategy => throw new System.NotImplementedException();
    }
}
