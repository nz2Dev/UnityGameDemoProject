using Game.Characters;
using Game.Characters.Extensions;
using Game.Combat.Stats;
using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    public class AttackAbility : BaseAbility<AttackAbilityConfig>
    {
        Character character;
        IWeapon weapon;
        HumanoidPathfinder pathfinder;

        CombatMember target;
        float lastAttackTime;

        void Start()
        {
            character = GetComponent<Character>();
            pathfinder = character.GetComponentInChildren<HumanoidPathfinder>();

            weapon = character.GetComponentInChildren<IWeapon>();
            if (weapon == null)
            {
                Debug.LogError("There are any character extensions that implements IWeapon interface");
                return;
            }

            weapon.OnHitEvent += () =>
            {
                // var health = go.GetComponent<Health>();
                // health.TakeDamage(damage);
            };

            enabled = false;
        }

        public void Attack(CombatMember combatMember)
        {
            var member = GetComponent<CombatMember>();
            // TODO Consider how to properly call it so that we don't brake incapsulation.
            member.StopAllAbility();

            enabled = true;
            pathfinder.Follow(combatMember.transform);
            target = combatMember;
        }

        public override void Stop()
        {
            if (!target)
            {
                return;
            }

            if (pathfinder.IsFollow(target.transform))
            {
                pathfinder.Follow(null);
            }
            target = null;
        }

        void Update()
        {
            if (target == null)
            {
                return;
            }

            // character.TurnTo(target.transform);

            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            bool inAttackRange = distanceToTarget < Config.AttackRadius;
            pathfinder.enabled = !inAttackRange;
            
            bool isTimeAllowToAttack = Time.time - lastAttackTime > Config.TimeBetweenAttack;
            if (isTimeAllowToAttack && inAttackRange) {
                lastAttackTime = Time.time;
                PerformAttack();
            }
        }

        void PerformAttack()
        {
            weapon.PlayAttack(target.GetComponent<Character>().FindPart(Part.HitArea));
        }
    }
}