using Assets._Project.Motion_Control;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._Project.Actors.Enemies
{
    public class Enemy : MonoBehaviour, ICanMove
    {
        private NavMeshAgent _navigationAgent;

        public Transform Transform => transform;

        public bool IsReachedTarget => _navigationAgent.isStopped;

        private void Awake()
        {
            _navigationAgent = GetComponent<NavMeshAgent>();
        }

        public void Follow(Vector3 target)
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
    }
}