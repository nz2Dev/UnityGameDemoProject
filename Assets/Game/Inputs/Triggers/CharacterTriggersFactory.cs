using Game.Characters;
using Game.Characters.Controllers;
using Game.Characters.Extensions;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;

namespace Game.Inputs.Triggers
{
    public class CharacterTriggersFactory
    {
        public static Trigger CreateMoveTrigger(Character character)
        {
            return new Trigger
            {
                Construction = new PointConstruction(),
                Context = new GroundContext(),
                EventConsumer = e => character.GetComponentInChildren<PathfindingFootsController>().Walk(e.Point)
            };
        }
    }
}