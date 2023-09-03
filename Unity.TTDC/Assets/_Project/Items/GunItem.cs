using UnityEngine;

namespace Assets._Project.Items
{
    public abstract class GunItem : WeaponItem 
    {
        [field: SerializeField] public float Spreed { get; private set; }
        [field: SerializeField] public int Capacity { get; private set; }
        [field: SerializeField] public float ReloadingSpeed { get; private set; }
    }
}
