using UnityEngine;

namespace Game.Data
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] Texture2D icon;
        // some common staff goes there. 
        // For example size (for Inventory)
        // Amount if it countable etc.

        public Texture2D GetIcon()
        {
            return icon;
        }

        public abstract void UseFor(GameObject gameObject);
    }
}
