using Assets._Project.Items;
using Assets._Project.Items.Use_Control;
using Assets._Project.Motion_Control;
using UnityEngine;

namespace Assets._Project.Actors.Player_Character
{
    public class Character : MonoBehaviour, ICanMove, IHaveEquipment, ICanUseItem
    {
        private ICanMove _mover;

        public Transform Transform => transform;
        [field: SerializeField] public Transform Hand { get; private set; }

        private void Awake()
        {
            CharacterController controller = GetComponent<CharacterController>();
            _mover = new CharacterControllerDrivedMover(Transform, controller);
        }

        public void Move(Vector3 motion) => _mover?.Move(motion);

        public void Rotate(Quaternion rotation) => _mover?.Rotate(rotation);
    }
}