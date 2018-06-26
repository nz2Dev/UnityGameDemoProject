using System;

namespace Game.Inputs
{
    public class Trigger
    {
        public Context Context { get; set; }
        public Construction Construction { get; set; }
        public Action<Event> EventConsumer { get; set; }
        public Action UnfocusConsumer { get; set; }

        public virtual void OnTrigger(Event triggeredEvent)
        {
            if (EventConsumer != null)
            {
                EventConsumer.Invoke(triggeredEvent);
            }
        }

        public virtual void Unfocus()
        {
            if (UnfocusConsumer != null)
            {
                UnfocusConsumer.Invoke();
            }
        }
    }
}
