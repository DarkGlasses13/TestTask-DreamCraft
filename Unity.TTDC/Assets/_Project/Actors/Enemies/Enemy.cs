using Assets._Project.Health_Control;
using Assets._Project.Motion_Control;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._Project.Actors.Enemies
{
    public class Enemy : MonoBehaviour, ICanMove, IHaveHealth
    {
        private NavMeshAgent _navigationAgent;

        public Transform Transform => transform;

        public string ID { get; private set; }

        public float RemainingDistance => _navigationAgent.remainingDistance;

        public void Construct(string id)
        {
            ID = id;
        }

        private void Awake()
        {
            _navigationAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 target)
        {
            _navigationAgent.SetDestination(target);
        }

        public void Move(Vector3 motion)
        {
            throw new System.NotImplementedException();
        }

        public void Rotate(Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        public void Kill()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            gameObject.SetActive(false);
        }

        public void Restore(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}