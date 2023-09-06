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

        private void OnEnable()
        {
            _trail.emitting = true;
        }

        public void Construct(string id)
        {
            ID = id;
        }

        public virtual void Move() 
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            OnHit?.Invoke(this);
        }

        private void OnDisable()
        {
            _trail.emitting = false;
        }
    }
}