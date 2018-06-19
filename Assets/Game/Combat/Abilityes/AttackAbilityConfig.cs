using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    [CreateAssetMenu(menuName = "Ability/Attack")]
    public class AttackAbilityConfig : BaseAbilityConfig
    {
        [SerializeField] int attackRadius = 10;

        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<AttackAbility>().SetConfig(this);
        }

        public int GetAttackRadius()
        {
            return attackRadius;
        }
    }
}