using Boo.Lang.Runtime;
using Game.Crafting;
using Game.Crafting.Actions;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;
using UnityEngine;

namespace Game.Inputs.Triggers
{
    public class CraftingTriggersFactory
    {
        public static Trigger Create(ICraftingAction action)
        {
            if (action is CutingTrees)
            {
                var cuttingTrees = (CutingTrees) action;
                return new Trigger
                {
                    Construction = new TargetConstruction(),
                    Context = new TreeContext(),
                    EventConsumer = e => cuttingTrees.Cut(e.GameObject.GetComponent<Tree>())
                };
            }

            throw new RuntimeException("Can't create trigger for unknown crafting action: " + action);
        }
    }
}