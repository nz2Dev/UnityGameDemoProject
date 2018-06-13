namespace Game.Inputs
{
    public abstract class Trigger
    {

        public abstract void OnTrigger(Event triggeredEvent);

        public abstract Construction GetConstruction();

        public abstract object GetContext();

    }
}
