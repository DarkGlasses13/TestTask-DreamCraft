using UnityEngine;

namespace Assets._Project
{
    public class MonoRunner : MonoBehaviour
    {
        protected Runner _runner;

        private void Start()
        {
            _runner?.RunAsync();
        }

        private void Update()
        {
            _runner?.Tick();
        }

        private void LateUpdate()
        {
            _runner?.LateTick();
        }

        private void FixedUpdate()
        {
            _runner?.FixedTick();
        }
    }
}