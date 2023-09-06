using Assets._Project.Items.Use_Control;
using System;

namespace Assets._Project.Items
{
    [Serializable]
    public class SinglefireItem : GunItem
    {
        public override void StopUse(ICanUseItem user)
        {
            _projectileController.Create(ProjectileKey, _gunInstance.Muzzle.position, _gunInstance.Muzzle.rotation);
        }
    }
}
