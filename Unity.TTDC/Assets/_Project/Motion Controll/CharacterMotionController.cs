using Assets._Project.Actors.Player_Character;
using Assets._Project.Architecture.Core;
using Assets._Project.Input;
using UnityEngine;

namespace Assets._Project.Motion_Controll
{
    public class CharacterMotionController : Controller
    {
        private readonly IPlayerInput _playerInput;
        private readonly ICanMove _movable;
        private CharacterConfig _config;
        private Quaternion _rotation;
        private Vector3 _motion;
        private float _rotationLerpTime;

        public CharacterMotionController(CharacterConfig configLoader, IPlayerInput playerInput, ICanMove movable)
        {
            _config = configLoader;
            _playerInput = playerInput;
            _movable = movable;
        }

        protected override void OnEnable()
        {
            _rotation = _movable.Transform.rotation;
            _playerInput.OnMotion += OnMotionInput;
        }

        public override void Tick()
        {
            Rotate();
            Move();
            _movable?.Move(_motion, _rotation);
        }

        private void Move()
        {
            _motion = _playerInput.MotionInput.magnitude * _config.MotionSpeed * Time.deltaTime * _movable.Transform.forward;
        }

        private void Rotate()
        {
            Vector2 input = _playerInput.MotionInput;
            Quaternion newRotation = _rotation;

            if (input != Vector2.zero)
            {
                newRotation = Quaternion.LookRotation(new(input.x, 0, input.y));
                _rotationLerpTime += Time.deltaTime * _config.RotationSpeed;
            }

            _rotation = Quaternion.Lerp(_rotation, newRotation, _rotationLerpTime);

            if (_rotationLerpTime >= 1)
                _rotationLerpTime = 0;
        }

        private void OnMotionInput(Vector2 vector)
        {
            _rotationLerpTime = 0;
        }

        protected override void OnDisable()
        {

        }
    }
}
