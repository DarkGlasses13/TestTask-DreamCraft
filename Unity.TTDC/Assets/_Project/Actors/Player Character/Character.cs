using Assets._Project.Inventory_System;
using Assets._Project.Motion_Controll;
using UnityEngine;

namespace Assets._Project.Actors.Player_Character
{
    public class Character : MonoBehaviour, ICanMove, ICanEquip
    {
        private ICanMove _mover;

        public Transform Transform => transform;
        [field: SerializeField] public Transform Hand { get; private set; }

        private void Awake()
        {
            CharacterController controller = GetComponent<CharacterController>();
            _mover = new CharacterControllerDrivedMover(Transform, controller);
        }

        public void Move(Vector3 motion, Quaternion rotation) => _mover?.Move(motion, rotation);
    }
}