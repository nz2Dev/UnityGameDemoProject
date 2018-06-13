using Game.Combat;
using Game.Inputs.Triggers;
using UnityEngine;

namespace Game.Inputs
{
    [RequireComponent(typeof(TriggersHost))]
    public class TriggersDefiner : MonoBehaviour
    {
        TriggersHost triggersHost;

        void Start()
        {
            triggersHost = GetComponent<TriggersHost>();
            DefineTriggers();
        }

        public void DefineTriggers()
        {
            var member = GetComponent<Member>();
            if (member)
            {
                foreach (var ability in member.GetAbilities())
                {
                    triggersHost.AddTrigger(AbilityTriggersFactory.Create(ability));
                }
            }
        }
    }
}