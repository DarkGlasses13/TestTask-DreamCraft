using Assets._Project.Actors.Player_Character;
using Assets._Project.Architecture.Core;
using Assets._Project.Input;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Assets._Project.Motion_Controll
{
    public class CharacterMotionController : Controller
    {
        private readonly IPlayerInput _playerInput;
        private readonly Camera _playerCamera;
        private readonly ICanMove _movable;
        private CharacterConfig _config;
        private Quaternion _rotation;
        private Vector3 _motion;
        private float _rotationLerpTime;
        private bool _isLooking;
        private RaycastHit[] _cameraRayHits = new RaycastHit[20];

        public CharacterMotionController(CharacterConfig configLoader, IPlayerInput playerInput,
            Camera playerCamera, ICanMove movable)
        {
            _config = configLoader;
            _playerInput = playerInput;
            _playerCamera = playerCamera;
            _movable = movable;
        }

        protected override void OnEnable()
        {
            _rotation = _movable.Transform.rotation;
            _playerInput.OnMotion += OnMotionInput;
            _playerInput.OnStartLooking += OnStartLooking;
            _playerInput.OnLookEnded += OnLookEnded;
        }

        public override void Tick()
        {
            Rotate();
            Move();
        }

        private void Move()
        {
            _motion = _isLooking 
                ? new Vector3(_playerInput.MotionInput.x, 0, _playerInput.MotionInput.y)
                : _playerInput.MotionInput.magnitude * _movable.Transform.forward;

            _movable?.Move(_config.MotionSpeed * Time.deltaTime * _motion);
        }

        private void Rotate()
        {
            Vector2 input = Vector2.zero;
            Quaternion newRotation = _rotation;

            if (_isLooking == false)
            {
                input = _playerInput.MotionInput;

                if (input != Vector2.zero)
                    _rotationLerpTime += Time.deltaTime * _config.WalkRotationSpeed;
            }
            else
            {
                Ray cameraRay = _playerCamera.ScreenPointToRay(_playerInput.LookInput);
                Physics.RaycastNonAlloc(cameraRay, _cameraRayHits);

                if (_cameraRayHits.Length > 0)
                {
                    Vector3 direction = _cameraRayHits[0].point - _movable.Transform.position;
                    input = new(direction.x, direction.z);
                }

                _rotationLerpTime += Time.deltaTime * _config.LookRotationSpeed;
            }

            if (input != Vector2.zero)
                newRotation = Quaternion.LookRotation(new(input.x, 0, input.y));

            _rotation = Quaternion.Lerp(_rotation, newRotation, _rotationLerpTime);

            if (_rotationLerpTime >= 1)
                _rotationLerpTime = 0;

            _movable?.Rotate(_rotation);
        }

        private void OnStartLooking()
        {
            _rotationLerpTime = 0;
            _isLooking = true;
        }

        private void OnLookEnded()
        {
            _rotationLerpTime = 0;
            _isLooking = false;
        }

        private void OnMotionInput(Vector2 vector)
        {
            if (_isLooking == false)
                _rotationLerpTime = 0;
        }

        protected override void OnDisable()
        {
            _playerInput.OnMotion -= OnMotionInput;
            _playerInput.OnStartLooking -= OnStartLooking;
            _playerInput.OnLookEnded -= OnLookEnded;
        }
    }
}
