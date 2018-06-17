using Game.Maining.Actions;
using UnityEngine;

namespace Game.Maining.Tools
{
    public class TreeAxe : Tool
    {
        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<CutingTrees>().SetConfig(this);
        }
    }
}