﻿using UnityEngine;

namespace Assets._Project.Motion_Control
{
    internal class CharacterControllerDrivedMover : ICanMove 
    {
        private readonly CharacterController _controller;

        public Transform Transform { get; private set; }

        public bool IsReachedTarget => throw new System.NotImplementedException();

        public CharacterControllerDrivedMover(Transform transform, CharacterController controller)
        {
            Transform = transform;
            _controller = controller;
        }

        public void Move(Vector3 motion) => _controller.Move(motion);

        public void Rotate(Quaternion rotation) => Transform.rotation = rotation;

        public void Follow(Vector3 target)
        {
            throw new System.NotImplementedException();
        }
    }
}