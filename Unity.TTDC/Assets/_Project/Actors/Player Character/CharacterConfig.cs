using UnityEngine;

namespace Assets._Project.Actors.Player_Character
{
    [CreateAssetMenu(menuName = "Config/Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public float MotionSpeed {  get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public int WeaponSlotsCount { get; internal set; }
    }
}
