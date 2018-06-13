using UnityEngine;

namespace Game.Utils
{
    public abstract class BehaviourConfig : ScriptableObject
    {
        public abstract MonoBehaviour AttachTo(GameObject gameObject);
    }
}