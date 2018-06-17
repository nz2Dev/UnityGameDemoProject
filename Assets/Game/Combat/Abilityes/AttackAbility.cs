using Game.Characters;
using Game.Characters.Extensions;
using Game.Characters.Plugins;
using Game.Combat.Stats;
using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    public class AttackAbility : ConfigurableBehaviour<AttackAbilityConfig>, IAbility
    {
        Character character;
        IWeapon weapon;

        void Start()
        {
            character = GetComponent<Character>();

            weapon = character.GetComponentInChildren<IWeapon>();
            if (weapon != null)
            {
                weapon.OnHitEvent += () =>
                {
                    // var health = go.GetComponent<Health>();
                    // health.TakeDamage(damage);
                };
            }
        }

        public void Attack(CombatMember combatMember)
        {
            print(gameObject.name + "Attack");
            weapon.PlayAttack(combatMember.GetComponent<Character>().FindPart(Part.HitArea));
        }

        public int GetAttackRadius()
        {
            return GetConfig().GetAttackRadius();
        }
    }
}