using Game.Characters;
using Game.Data;
using Game.Maining.Subjects;
using Game.Maining.Tools;
using Game.Utils;

namespace Game.Maining.Actions
{
    public class PickingItems : ConfigurableBehaviour<Hand>, IMainingAction
    {
        Inventory inventory;

        void Start()
        {
            inventory = GetComponent<Inventory>();
        }

        public void PickItem(ItemPickup itemPickup)
        {
            // target = itemPickup;
            // set destination for CharacterPathfindingController

            // But now, lets simply add it to inventory right away
            inventory.AddItem(itemPickup.GetItem());
        }

        void Update()
        {
            // check if character near ItemPickup position

            // inventory.AddItem(target.GetItem());
            // target.DestroyGraphics()
        }
    }
}