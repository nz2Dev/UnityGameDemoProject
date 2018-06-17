using Boo.Lang.Runtime;
using Game.Inputs.Constructions;
using Game.Inputs.Contexts;
using Game.Maining;
using Game.Maining.Actions;
using Game.Maining.Subjects;
using UnityEngine;

namespace Game.Inputs.Triggers
{
    public class MainingTriggersFactory
    {
        public static Trigger Create(IMainingAction action)
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

            if (action is PickingItems)
            {
                var pickingItems = (PickingItems) action;
                return new Trigger
                {
                    Construction = new PointConstruction(),
                    Context = new ItemsContext(),
                    EventConsumer = e => pickingItems.PickItem(e.GameObject.GetComponent<ItemPickup>())
                };
            }

            throw new RuntimeException("Can't create trigger for unknown maining action: " + action);
        }
    }
}