using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    [CreateAssetMenu(menuName = "Ability/Attack")]
    public class AttackAbilityConfig : BaseAbilityConfig
    {
        [SerializeField] int attackRadius = 10;
        [SerializeField] float timeBetweenAttack = 1f;

        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<AttackAbility>().SetConfig(this);
        }

        public int AttackRadius {
            get {
                return attackRadius;
            }
        }

        public float TimeBetweenAttack
        {
            get { return timeBetweenAttack; }
        }
    }
}