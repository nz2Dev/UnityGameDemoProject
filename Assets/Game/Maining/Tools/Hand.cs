using Game.Maining.Actions;
using UnityEngine;

namespace Game.Maining.Tools
{
    public class Hand : Tool
    {
        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<PickingItems>().SetConfig(this);
        }
    }
}