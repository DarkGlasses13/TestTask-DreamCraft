using UnityEngine;

namespace Assets._Project.Items
{
    public class MeleeAttackStrategy : IItemUseStrategy
    {
        private readonly MeleeItem _data;

        public MeleeAttackStrategy(MeleeItem data)
        {
            _data = data;
        }

        public void FixedUpdate(ICanUseItem user) { }

        public void Start(ICanUseItem user)
        {
            Debug.Log("Melee");
        }

        public void Stop(ICanUseItem user) { }

        public void Update(ICanUseItem user) { }
    }
}
