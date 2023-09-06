using Assets._Project.Health_Control;
using Assets._Project.Items;
using System;
using UnityEngine;

namespace Assets._Project.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile, IHaveHealth> OnHit;

        [SerializeField] private float _speed;
        private GunItem _gun;

        public TrailRenderer Trail { get; private set; }
        public string ID => _gun.ID;
        public int Damage => _gun.Damage;


        private void Awake()
        {
            Trail = GetComponent<TrailRenderer>();
        }

        public void Construct(GunItem gun)
        {
            _gun = gun;
        }

        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            OnHit?.Invoke(this, other.GetComponent<IHaveHealth>());
            //OnHit?.Invoke(this, other.GetComponent<IHitBox>());
        }
    }
}