using Assets._Project.Architecture.Core;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Project.Input
{
    public class PlayerInputController : Controller, IPlayerInput
    {
        public event Action<Vector2> OnMotion;
        public event Action OnAttack;
        public event Action<float> OnWeaponSwap;

        private Controls _inputActions;

        public Vector2 MotionInput => _inputActions.Character.Motion.ReadValue<Vector2>();

        protected override void OnEnable()
        {
            _inputActions ??= new();
            _inputActions?.Enable();
            _inputActions.Character.Motion.performed += Move;
            _inputActions.Character.Motion.canceled += Move;
            _inputActions.Character.Attack.performed += Attack;
            _inputActions.Character.WeaponSwap.performed += SwapWeapon;
        }

        private void Move(InputAction.CallbackContext context)
        {
            OnMotion?.Invoke(MotionInput);
        }

        private void Attack(InputAction.CallbackContext context)
        {
            OnAttack?.Invoke();
        }

        private void SwapWeapon(InputAction.CallbackContext context)
        {
            OnWeaponSwap?.Invoke(context.ReadValue<float>());
        }

        protected override void OnDisable()
        {
            _inputActions.Character.Motion.performed -= Move;
            _inputActions.Character.Motion.canceled -= Move;
            _inputActions.Character.Attack.performed -= Attack;
            _inputActions.Character.WeaponSwap.performed -= SwapWeapon;
            _inputActions?.Disable();
        }
    }
}
