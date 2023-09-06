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
        [SerializeField] private float _lifetime;
        private GunItem _gun;

        public TrailRenderer Trail { get; private set; }
        public string ID => _gun.ProjectileKey;
        public int Damage => _gun.Damage;


        private void Awake()
        {
            Trail = GetComponent<TrailRenderer>();
        }

        private void OnEnable()
        {
            Invoke(nameof(OnLifetimeEnded), _lifetime);
        }

        private void OnLifetimeEnded() => gameObject.SetActive(false);

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