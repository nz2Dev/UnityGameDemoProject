using Game.Characters;
using Game.Crafting.Subjects;
using Game.Crafting.Tools;
using Game.Data;
using Game.Utils;
using UnityEngine;

namespace Game.Crafting.Actions
{
    public class PickingItems : ConfigurableBehaviour<Hand>
    {
        Inventory inventory;
        Character character;

        ItemPickup target;

        void Start()
        {
            inventory = GetComponent<Inventory>();
            character = GetComponent<Character>();
        }

        public void PickItem(ItemPickup itemPickup)
        {
            target = itemPickup;
            // set destination for CharacterPathfindingController
        }

        void Update()
        {
            // check if character near ItemPickup position
            
            // inventory.AddItem(target.GetItem());
            // target.DestroyGraphics()
        }
    }
}