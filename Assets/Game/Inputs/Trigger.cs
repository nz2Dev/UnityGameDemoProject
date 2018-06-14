using System;

namespace Game.Inputs
{
    public class Trigger
    {
        public Construction Construction { get; set; }
        public object Context { get; set; }
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
