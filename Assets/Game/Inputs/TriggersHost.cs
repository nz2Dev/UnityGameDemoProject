using System.Collections.Generic;
using UnityEngine;

namespace Game.Inputs
{
    public class TriggersHost : MonoBehaviour
    {
        List<Trigger> triggers = new List<Trigger>();

        public void AddTrigger(Trigger trigger)
        {
            triggers.Add(trigger);
        }

        public void Clear()
        {
            triggers.Clear();
        }

        public IEnumerable<Trigger> GetTriggers()
        {
            return triggers;
        }
    }
}