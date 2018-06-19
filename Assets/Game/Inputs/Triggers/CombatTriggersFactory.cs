﻿using Boo.Lang.Runtime;
using Game.Combat;
using Game.Combat.Abilityes;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;

namespace Game.Inputs.Triggers
{
    public class CombatTriggersFactory
    {
        public static Trigger Create(IAbility ability)
        {
            if (ability is AttackAbility)
            {
                var attackAbility = (AttackAbility) ability;
                return new Trigger
                {
                    Context = new MemberContext(),
                    Construction = new TargetConstruction {Icon = attackAbility.GetConfig().GetIcon()},
                    EventConsumer = e => attackAbility.Attack(e.GameObject.GetComponent<CombatMember>())
                };
            }

            throw new RuntimeException("Can't create trigger for unknown ability: " + ability);
        }
    }
}