using Assets._Project.Items.Use_Control;
using System;
using UnityEngine;

namespace Assets._Project.Items
{
    [Serializable]
    public class ShotgunItem : SinglefireItem
    {
        [field: SerializeField] public int ProjectilesPerShot { get; private set; }

        public override void Use(ICanUseItem user)
        {

            for (float i = -Spreed / 2; i < Spreed / 2; i += Spreed / ProjectilesPerShot)
            {
                Quaternion rotation = Quaternion.Euler(Vector3.up * (_gunInstance.Muzzle.transform.eulerAngles.y + i));
                _projectileController.Create("Bullet", _gunInstance.Muzzle.transform.position, rotation);
            }

        }
    }
}
