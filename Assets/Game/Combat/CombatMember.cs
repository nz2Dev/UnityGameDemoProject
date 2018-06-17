using System.Collections.Generic;
using Game.Characters;
using Game.Utils;
using UnityEngine;

namespace Game.Combat
{
    [RequireComponent(typeof(Character))]
    public class CombatMember : MonoBehaviour
    {
        [SerializeField] BehaviourConfig[] buildInConfigs = null;

        List<IAbility> abilityes = new List<IAbility>();
        List<IStat> stats = new List<IStat>();
        List<IModifier> modifiers = new List<IModifier>();

        void Awake()
        {
            foreach (var config in buildInConfigs)
            {
                Apply(config);
            }
        }

        public void Apply(BehaviourConfig behaviourConfig)
        {
            var ability = behaviourConfig.AttachTo(gameObject) as IAbility;
            abilityes.Add(ability);
        }

        public IEnumerable<IAbility> GetAbilities()
        {
            return abilityes;
        }
    }
}