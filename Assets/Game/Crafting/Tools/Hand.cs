using Game.Crafting.Actions;
using UnityEngine;

namespace Game.Crafting.Tools
{
    public class Hand : Tool
    {
        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<PickingItems>().SetConfig(this);
        }
    }
}