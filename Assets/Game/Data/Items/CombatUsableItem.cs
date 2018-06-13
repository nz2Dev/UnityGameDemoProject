using Game.Combat;
using UnityEngine;

namespace Game.Data.Items
{
    public class CombatUsableItem : Item
    {
        // [SerializeField] ThingsThatCanBeDrinkedOrEated things;
        // e.g Cup of Healling

        public override void UseFor(GameObject gameObject)
        {
//            var member = gameObject.GetComponent<Member>();
//            member.Apply(things);
        }
    }
}