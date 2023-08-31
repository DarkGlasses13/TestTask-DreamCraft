using UnityEngine;

namespace Assets._Project.Motion_Controll
{
    public interface ICanMove
    {
        Transform Transform { get; }

        void Move(Vector3 motion, Quaternion rotation);
    }
}
