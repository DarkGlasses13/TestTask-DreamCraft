using UnityEngine;

namespace Assets._Project.Inventory_System
{
    public class ItemInstance : MonoBehaviour
    {
        public string ID {  get; private set; }

        public virtual void Construct(string id) => ID = id;
    }
}