using UnityEngine;

namespace Assets._Project.Items
{
    public class ShotgunAttackStrategy : IItemUseStrategy
    {
        private ShotgunItem _data;

        public ShotgunAttackStrategy(ShotgunItem data)
        {
            _data = data;
        }

        public void FixedUpdate(ICanUseItem user) { }

        public void Start(ICanUseItem user)
        {

            Debug.Log("Shotgun");
        }

        public void Stop(ICanUseItem user) { }

        public void Update(ICanUseItem user) { }
    }
}
