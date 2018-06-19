using System.Collections.Generic;
using Game.Inputs;
using UnityEngine;

namespace Game.UI.Triggers
{
    public abstract class Activator : MonoBehaviour
    {
        public Trigger AssignedTrigger { get; protected set; }
        
        // TODO Consider to add Refresh() methdos for case when TriggersHost was changed or Triggers was redefined
        public abstract void AssignTrigger(IEnumerable<Trigger> triggers);
        public abstract bool IsActivated();
        public abstract bool IsDeactivate();

    }
}