using Game.Characters;
using Game.Combat.Stats;
using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    public class AttackAbility : ConfigurableBehaviour<AttackAbilityConfig>, IAbility
    {
//        Character character;
//        int damage;

        public void Attack(GameObject go)
        {
            print(gameObject.name + "Attack");

//            var health = go.GetComponent<Health>();
//            health.TakeDamage(damage);

//            var sword = character.GetEquipmentOn(Hand.Left) as Sword;
//            sword.Attack(go.GetComponent<Character>().getHitArea());
        }

        public void IncreaseDamage()
        {
//            damage += 10;
        }

        public int GetAttackRadius()
        {
            return 10;
        }
    }
}