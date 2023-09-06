using UnityEngine;

namespace Assets._Project.Motion_Control
{
    public interface ICanMove
    {
        Transform Transform { get; }
        bool IsReachedTarget { get; }

        void Move(Vector3 motion);
        void Rotate(Quaternion rotation);
        void Follow(Vector3 target);
    }
}
