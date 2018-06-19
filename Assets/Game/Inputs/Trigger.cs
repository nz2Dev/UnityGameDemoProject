using System;

namespace Game.Inputs
{
    public class Trigger
    {
        public Context Context { get; set; }
        public Construction Construction { get; set; }
        public Action<Event> EventConsumer { get; set; }

        public virtual void OnTrigger(Event triggeredEvent)
        {
            if (EventConsumer != null)
            {
                EventConsumer.Invoke(triggeredEvent);
            }
        }
    }
}
