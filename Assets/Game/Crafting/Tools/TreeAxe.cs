using Game.Crafting.Actions;
using UnityEngine;

namespace Game.Crafting.Tools
{
    public class TreeAxe : Tool
    {
        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<CutingTrees>().SetConfig(this);
        }
    }
}