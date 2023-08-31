using Assets._Project.Motion_Controll;
using UnityEngine;

namespace Assets._Project.Actors.Player_Character
{
    internal class CharacterControllerDrivedMover : ICanMove
    {
        private readonly CharacterController _controller;

        public Transform Transform { get; private set; }

        public CharacterControllerDrivedMover(Transform transform, CharacterController controller)
        {
            Transform = transform;
            _controller = controller;
        }

        public void Move(Vector3 motion, Quaternion rotation)
        {
            _controller.Move(motion);
            Transform.rotation = rotation;
        }
    }
}