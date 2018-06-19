using Game.Characters;
using Game.Combat;

namespace Game.Inputs.Triggers
{
    public class TriggersDefiner
    {
        public static void ObserveChanges(TriggersHost triggersHost)
        {
            var character = triggersHost.GetComponent<Character>();
            if (character)
            {
                triggersHost.AddTrigger(CharacterTriggersFactory.CreateMoveTrigger(character));
            }

            var combatMember = triggersHost.GetComponent<CombatMember>();
            if (combatMember)
            {
                DefineCombatMemberTriggers(triggersHost, combatMember);
                combatMember.OnStateChanged += () =>
                {
                    DefineCombatMemberTriggers(triggersHost, combatMember);
                };
            }
        }

        static void DefineCombatMemberTriggers(TriggersHost triggersHost, CombatMember combatMember)
        {
            foreach (var ability in combatMember.GetAbilities())
            {
                triggersHost.AddTrigger(CombatTriggersFactory.Create(ability));
            }
        }
    }
}