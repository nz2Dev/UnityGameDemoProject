using System.Linq;
using Game.Characters;
using Game.Combat;
using Game.Inputs;
using Game.Inputs.Contexts;
using Game.Inputs.Triggers;
using UnityEngine;

namespace Game.UI
{
    public class InputUI : MonoBehaviour
    {
        [SerializeField] TriggersHost triggersHost = null;

        void Start()
        {
            DefineTriggers();
        }

        void Update()
        {
            if (triggersHost == null)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                triggersHost.GetTriggers().First().OnTrigger(new Inputs.Event
                {
                    GameObject = null,
                    Point = Vector3.zero
                });
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                TriggerWalkToVector000();
            }
        }

        void TriggerWalkToVector000()
        {
            triggersHost.GetTriggers()
                .First(t => t.Context is GroundContext)
                .OnTrigger(new Inputs.Event
                {
                    Point = Vector3.zero
                });
        }

        void DefineTriggers()
        {
            var character = triggersHost.GetComponent<Character>();
            if (character)
            {
                triggersHost.AddTrigger(CharacterTriggersFactory.CreateMoveTrigger(character));
            }

            var member = triggersHost.GetComponent<CombatMember>();
            if (member)
            {
                foreach (var ability in member.GetAbilities())
                {
                    triggersHost.AddTrigger(CombatTriggersFactory.Create(ability));
                }
            }
        }
    }
}