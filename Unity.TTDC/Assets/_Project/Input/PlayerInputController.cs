﻿using Assets._Project.Architecture.Core;
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

        public Vector2 MotionInput { get; private set; }

        public PlayerInputController(Controls inputActions)
        {
            _inputActions = inputActions;
        }

        protected override void OnEnable()
        {
            _inputActions ??= new();
            _inputActions?.Enable();
            _inputActions.Character.Motion.performed += Move;
            _inputActions.Character.Attack.performed += Attack;
            _inputActions.Character.WeaponSwap.performed += SwapWeapon;
        }

        private void Move(InputAction.CallbackContext context)
        {
            MotionInput = context.ReadValue<Vector2>();
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
            _inputActions?.Disable();
        }
    }
}