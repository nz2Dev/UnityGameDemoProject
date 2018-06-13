using Boo.Lang.Runtime;
using Game.Combat;
using Game.Combat.Abilityes;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;

namespace Game.Inputs.Triggers
{
    public class AbilityTriggersFactory
    {
        public static AbilityTrigger Create(IAbility ability)
        {
            if (ability is AttackAbility)
            {
                var attackAbility = (AttackAbility) ability;
                return new AbilityTrigger
                {
                    Construction = new TargetConstruction(),
                    Context = new MemberContext(),
                    EventConverter = e => attackAbility.Attack(e.GameObject)
                };
            }

            throw new RuntimeException("Can't create trigger for unknown ability: " + ability);
        }
    }
}