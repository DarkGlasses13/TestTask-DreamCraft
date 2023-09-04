using UnityEngine;

namespace Assets._Project.Camera_Control
{
    public class PlayerCameraLoader : LocalAssetLoader<Camera>
    {
        public override string Key => "Player Camera";
    }
}
