using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    public abstract class BaseAbilityConfig : BehaviourConfig
    {
        [SerializeField] Sprite icon = null;

        public Sprite Icon
        {
            get { return icon; }
        }
    }
}