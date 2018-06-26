using Game.Characters;
using Game.Characters.Extensions;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;

namespace Game.Inputs.Triggers
{
    public class CharacterTriggersFactory
    {
        public static Trigger CreateMoveTrigger(Character character)
        {
            var pathfinder = character.GetComponentInChildren<HumanoidPathfinder>();
            return new Trigger
            {
                Construction = new PointConstruction {Icon = pathfinder.WalkIcon},
                Context = new GroundContext(),
                EventConsumer = e => pathfinder.Walk(e.Point),
                UnfocusConsumer = () => pathfinder.Follow(null)

                // TODO implement condition that will determine if Trigger should unfocus based on a new Trigger's Type for example.
                // It may be useful in case when some other Trigger can be triggered in 
                // paralel without any problem and the old one that needs to be unfocused still have unfinished tasks.
            };
        }
    }
}