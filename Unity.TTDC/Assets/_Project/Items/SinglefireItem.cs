using Assets._Project.Items.Use_Control;
using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class SinglefireItem : GunItem
    {
        public override void Use(ICanUseItem user)
        {
            _projectileController.Create("Bullet", _gunInstance.Muzzle);
        }
    }
}
