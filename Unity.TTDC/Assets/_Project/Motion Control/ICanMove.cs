using UnityEngine;

namespace Assets._Project.Motion_Control
{
    public interface ICanMove
    {
        Transform Transform { get; }
        float RemainingDistance { get; }

        void Move(Vector3 motion);
        void Rotate(Quaternion rotation);
        void MoveTo(Vector3 target);
    }
}
