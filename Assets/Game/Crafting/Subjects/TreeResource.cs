using Game.Data;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Game.Crafting.Subjects
{
    public class TreeResource : MonoBehaviour
    {
        [SerializeField] int amount = 1;

        public int GetAmount()
        {
            return amount;
        }
    }
}