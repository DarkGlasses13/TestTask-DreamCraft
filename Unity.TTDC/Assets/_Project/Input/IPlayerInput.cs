using System;
using UnityEngine;

namespace Assets._Project.Input
{
    public interface IPlayerInput
    {
        event Action<Vector2> OnMotion;
        event Action OnAttack;
        event Action<float> OnItemSwap;

        Vector2 MotionInput { get; }
    }
}
