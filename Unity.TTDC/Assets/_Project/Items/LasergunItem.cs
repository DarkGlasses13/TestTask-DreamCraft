using Assets._Project.Items.Use_Control;
using System;
using UnityEngine;

namespace Assets._Project.Items
{
    [Serializable]
    public class LasergunItem : GunItem
    {
        public override void Use(ICanUseItem user)
        {
            Debug.Log("Laser attack");
        }
    }
}
