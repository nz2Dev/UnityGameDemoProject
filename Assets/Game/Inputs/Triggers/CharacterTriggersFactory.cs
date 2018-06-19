using Game.Characters;
using Game.Characters.Controllers;
using Game.Characters.Extensions;
using Game.Characters.Extensions.Body;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;

namespace Game.Inputs.Triggers
{
    public class CharacterTriggersFactory
    {
        public static Trigger CreateMoveTrigger(Character character)
        {
            var pathfinder = character.GetComponentInChildren<PathfindingFootsController>();
            return new Trigger
            {
                Construction = new PointConstruction {Icon = pathfinder.WalkIcon},
                Context = new GroundContext(),
                EventConsumer = e => pathfinder.Walk(e.Point)
            };
        }
    }
}