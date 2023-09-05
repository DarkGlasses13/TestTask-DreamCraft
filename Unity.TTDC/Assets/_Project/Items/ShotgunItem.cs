using Assets._Project.Items.Use_Control;
using System;
using UnityEngine;

namespace Assets._Project.Items
{
    [Serializable]
    public class ShotgunItem : GunItem
    {
        public override void Use(ICanUseItem user)
        {
            Debug.Log("Shotgun attack");
        }
    }
}
