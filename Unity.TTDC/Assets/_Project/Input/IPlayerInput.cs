using System;
using UnityEngine;

namespace Assets._Project.Input
{
    public interface IPlayerInput
    {
        event Action<Vector2> OnMotion;
        event Action OnAttack;
        event Action<float> OnItemSwap;
        event Action OnLookEnded;
        event Action OnStartLooking;

        Vector2 MotionInput { get; }
        Vector2 LookInput { get; }
    }
}
