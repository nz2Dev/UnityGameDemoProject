﻿using System;
using System.Collections.Generic;
using Game.Characters;
using Game.Utils;
using UnityEngine;

namespace Game.Combat
{
    [RequireComponent(typeof(Character))]
    public class CombatMember : MonoBehaviour
    {
        public event Action OnStateChanged;

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
            NotifyStateChanged();
        }

        public void StopAllAbility()
        {
            foreach (var ability in GetAbilities())
            {
                ability.Stop();
            }
        }

        public IEnumerable<IAbility> GetAbilities()
        {
            return abilityes;
        }

        void NotifyStateChanged()
        {
            if (OnStateChanged != null)
            {
                OnStateChanged();
            }
        }
    }
}