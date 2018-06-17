using System.Collections.Generic;
using Game.Characters;
using UnityEngine;

namespace Game.Data
{
    [RequireComponent(typeof(Character))]
    public class Inventory : MonoBehaviour
    {
        [SerializeField] Item[] buildInItems = null;

        List<Item> items = new List<Item>();

        void Start()
        {
            foreach (var buildInItem in buildInItems)
            {
                AddItem(buildInItem);
            }
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
    }
}
