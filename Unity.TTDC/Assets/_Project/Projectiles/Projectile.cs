using System;
using UnityEngine;

namespace Assets._Project.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile> OnHit;

        [SerializeField] private float _speed;
        private TrailRenderer _trail;

        public string ID { get; private set; }

        private void Awake()
        {
            _trail = GetComponent<TrailRenderer>();
        }

        public void Construct(string id)
        {
            ID = id;
        }

        private void Update() 
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            OnHit?.Invoke(this);
        }
    }
}