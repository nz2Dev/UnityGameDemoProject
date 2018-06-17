using Game.Characters;
using Game.Combat;
using Game.Utils;
using UnityEngine;

namespace Game.Data.Items.Equipments
{
    [CreateAssetMenu(menuName = "Items/Equipments")]
    public class EquipmentableItem : Item
    {
        [SerializeField] Plugin plugin = null;
        [SerializeField] BehaviourConfig[] configs = null;
        [SerializeField] Slot slot = Slot.Body;

        public override void UseFor(GameObject gameObject)
        {
            var equipment = new Equipment { Item = this, Slot = slot };

            var eqAvatar = gameObject.GetComponent<EquipmentAvatar>();
            if (eqAvatar.Equipe(equipment))
            {
                plugin.ApplyOn(gameObject.GetComponent<Character>());

                var combatMember = gameObject.GetComponent<CombatMember>();
                foreach (var behaviourConfig in configs)
                {
                    combatMember.Apply(behaviourConfig);
                }
            }
        }
    }
}