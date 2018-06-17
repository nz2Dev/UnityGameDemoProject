using System;
using Game.Data;
using UnityEngine;

namespace Game.Maining.Subjects
{
    // Represent item as graphic in word
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] Item itemToPickup = null;
        
        public Item GetItem()
        {
            return itemToPickup;
        }
    }
}