using Assets._Project.Items.Use_Control;
using System;
using UnityEngine;

namespace Assets._Project.Items
{
    [Serializable]
    public class AutomaticItem : GunItem
    {
        [field: SerializeField] public float FireRate { get; private set; }
        protected float _time;

        protected override void OnInstanceLoaded(GameObject instance)
        {
            base.OnInstanceLoaded(instance);
        }

        public override void Use(ICanUseItem user)
        {
            if (_time == 0)
            {
                _projectileController
                    .Create(ProjectileKey, _gunInstance.Muzzle.transform.position, _gunInstance.Muzzle.transform.rotation);

            }

            _time += Time.deltaTime;

            if (_time >= 1 / FireRate)
                _time = 0;
        }
    }
}
