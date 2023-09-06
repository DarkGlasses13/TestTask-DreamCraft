using UnityEngine;

namespace Assets._Project.Motion_Control
{
    public interface ICanMove
    {
        Transform Transform { get; }

        void Move(Vector3 motion);
        void Rotate(Quaternion rotation);
    }
}
