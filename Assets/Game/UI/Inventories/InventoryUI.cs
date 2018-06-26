using System.Linq;
using Game.Data;
using UnityEngine;

namespace Game.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] Inventory inventory = null;

        void Update()
        {
            if (!inventory)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                inventory.GetItems().First().UseFor(inventory.gameObject);
            }
        }
    }
}