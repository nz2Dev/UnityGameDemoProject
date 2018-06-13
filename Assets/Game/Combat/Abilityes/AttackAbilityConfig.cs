using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    [CreateAssetMenu(menuName = "Game/Ability/Attack")]
    public class AttackAbilityConfig : BehaviourConfig
    {
        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<AttackAbility>().SetConfig(this);
        }
    }
}