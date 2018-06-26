using Game.Characters;
using Game.Characters.Extensions;
using Game.Data;
using Game.Maining.Tools;
using Game.Utils;
using UnityEngine;

namespace Game.Maining.Actions
{
    public class CutingTrees : ConfigurableBehaviour<TreeAxe>, IMainingAction
    {
        const int DistanceToCut = 1;

        Inventory inventory;
        Character character;

        Tree target;

        void Start()
        {
            inventory = GetComponent<Inventory>();
            character = GetComponent<Character>();
        }

        public void Cut(Tree tree)
        {
            target = tree;

            var pathfinder = character.GetComponent<HumanoidPathfinder>();
            pathfinder.Walk(tree.transform.position);
        }

        void Update()
        {
            if (Vector3.Distance(character.transform.position, target.transform.position) < DistanceToCut)
            {
                // var amount = target.GetTreeAmount();
                // inventory.AddItem(new TreeItem(amount));
                print(name + " cut the tree: " + target.name);

                // target.PlayDestroyAnim();
                Destroy(target);
            }
        }
    }
}