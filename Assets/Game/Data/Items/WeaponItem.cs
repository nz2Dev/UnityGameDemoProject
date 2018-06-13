using Game.Characters;
using Game.Combat;
using Game.Combat.Abilityes;
using UnityEngine;

namespace Game.Data.Items
{
    public class WeaponItem : Item
    {
        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AttackAbilityConfig attackAbilityConfig;

        public override void UseFor(GameObject gameObject)
        {
            var character = gameObject.GetComponent<Character>();
//            character.PlugIn(weaponPrefab);

            var combatMember = gameObject.GetComponent<Member>();
//            combatMember.AddAbility(attackAbbilityConfig);
        }
    }
}