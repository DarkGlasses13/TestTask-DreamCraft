using UnityEngine;

namespace Assets._Project.Items
{
    public class SinglefireAttackStrategy : IItemUseStrategy
    {
        private SinglefireItem _data;

        public SinglefireAttackStrategy(SinglefireItem data)
        {
            _data = data;
        }

        public void FixedUpdate(ICanUseItem user) { }

        public void Start(ICanUseItem user)
        {
            Debug.Log("Singlefire");
        }

        public void Stop(ICanUseItem user) { }

        public void Update(ICanUseItem user) { }
    }
}
