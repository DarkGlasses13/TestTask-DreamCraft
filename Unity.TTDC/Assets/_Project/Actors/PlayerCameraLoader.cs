using UnityEngine;

namespace Assets._Project.Actors
{
    public class PlayerCameraLoader : LocalAssetLoader<Camera>
    {
        public override string Key => "Player Camera";
    }
}
