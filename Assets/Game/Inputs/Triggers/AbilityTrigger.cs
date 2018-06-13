using System;

namespace Game.Inputs.Triggers
{
    public class AbilityTrigger : Trigger
    {
        public Construction Construction { get; set; }
        public object Context { get; set; }
        public Action<Event> EventConverter { get; set; }

        public override void OnTrigger(Event triggeredEvent)
        {
            EventConverter(triggeredEvent);
        }

        public override Construction GetConstruction()
        {
            return Construction;
        }

        public override object GetContext()
        {
            return Context;
        }
    }
}