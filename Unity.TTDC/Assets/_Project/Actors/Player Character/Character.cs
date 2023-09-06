using Assets._Project.Health_Control;
using Assets._Project.Items;
using Assets._Project.Items.Use_Control;
using Assets._Project.Motion_Control;
using UnityEngine;

namespace Assets._Project.Actors.Player_Character
{
    public class Character : MonoBehaviour, ICanMove, IHaveEquipment, ICanUseItem, IHaveHealth
    {
        private ICanMove _mover;

        public Transform Transform => transform;
        [field: SerializeField] public Transform Hand { get; private set; }

        public float RemainingDistance => throw new System.NotImplementedException();

        private void Awake()
        {
            CharacterController controller = GetComponent<CharacterController>();
            _mover = new CharacterControllerDrivedMover(Transform, controller);
        }

        public void Move(Vector3 motion) => _mover?.Move(motion);

        public void Rotate(Quaternion rotation) => _mover?.Rotate(rotation);

        public void MoveTo(Vector3 target)
        {
            throw new System.NotImplementedException();
        }

        public void Kill()
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Restore(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}