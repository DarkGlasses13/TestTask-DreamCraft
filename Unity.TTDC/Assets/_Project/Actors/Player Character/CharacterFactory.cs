using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._Project.Actors.Player_Character
{
    public class CharacterFactory
    {
        public async Task<Character> GetCreatedAsync(Vector3 position, Quaternion rotation, Transform parent)
        {
            GameObject instance = await Addressables.InstantiateAsync("Character", position, rotation, parent).Task;
            Character character = instance.GetComponent<Character>();
            return character;
        }
    }
}
