﻿using Game.Characters;
using Game.Characters.Controllers;
using Game.Crafting.Tools;
using Game.Data;
using Game.Utils;
using UnityEngine;

namespace Game.Crafting.Actions
{
    public class CutingTrees : ConfigurableBehaviour<TreeAxe>, ICraftingAction
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

            var pathfinder = character.GetComponent<PathfindingCharacterControl>();
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