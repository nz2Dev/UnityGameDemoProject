using UnityEngine;

namespace Game.Maining.Subjects
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