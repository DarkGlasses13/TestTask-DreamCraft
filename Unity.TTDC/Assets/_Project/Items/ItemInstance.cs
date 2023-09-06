using UnityEngine;

namespace Assets._Project.Items
{
    public class ItemInstance : MonoBehaviour
    {
        public string ID {  get; private set; }

        public virtual void Construct(string id) => ID = id;
    }
}