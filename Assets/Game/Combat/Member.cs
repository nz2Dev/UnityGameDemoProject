using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Game.Combat
{
    public class Member : MonoBehaviour
    {
        [SerializeField] BehaviourConfig[] buildInConfigs = null;

        List<IAbility> abilityes = new List<IAbility>();
        List<IStat> stats = new List<IStat>();

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