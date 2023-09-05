using UnityEngine;

namespace Assets._Project.Items
{
    public class GunInstance : ItemInstance, IGunInstance
    {
        [SerializeField] private Transform _muzzle;

        public Transform Muzzle => _muzzle;
    }
}
