using UnityEngine;

namespace Assets._Project.Items
{
    public abstract class GunItem : WeaponItem 
    {
        protected GunInstance _gunInstance;

        [field: SerializeField] public float Spreed { get; private set; }
        [field: SerializeField] public int Capacity { get; private set; }
        [field: SerializeField] public float ReloadingSpeed { get; private set; }
        [field: SerializeField] public string ProjectileKey { get; private set; }

        protected override void OnInstanceLoaded(GameObject instance)
        {
            base.OnInstanceLoaded(instance);
            _gunInstance = instance.GetComponent<GunInstance>();
        }
    }
}
