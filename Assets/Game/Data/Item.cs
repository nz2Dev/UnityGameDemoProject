using UnityEngine;

namespace Game.Data
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] Texture2D icon = null;
        [SerializeField] string description = "Unknown description";
        
        // some common staff goes there. 
        // For example size (for Inventory)
        // Amount if it countable etc.

        public abstract void UseFor(GameObject gameObject);

        // TODO public abstract void Unuse();

        public virtual string FormatDescription()
        {
            return description;
        }

        public Texture2D GetIcon()
        {
            return icon;
        }
    }
}
