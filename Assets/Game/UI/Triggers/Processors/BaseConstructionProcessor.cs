using Game.Inputs;
using UnityEngine;

namespace Game.UI.Triggers.Processors
{
    public abstract class BaseConstructionProcessor<TConfig> : MonoBehaviour, IConstructionProcessor where TConfig : ConstructionProcessorConfig
    {
        public TConfig Config { get; private set; }
        protected Trigger Trigger { get; private set; }

        public void SetConfig(TConfig config)
        {
            Config = config;
        }

        public void Init(Trigger trigger)
        {
            Trigger = trigger;
            OnInitTrigger();
        }

        protected virtual void OnInitTrigger()
        {            
        }

        public virtual void UpdateProcessor()
        {
        }

        public virtual bool IsFinish(Activator activator)
        {
            return activator.IsDeactivate();
        }

        public virtual void Destroy()
        {
        }

        public T GetConstructionAs<T>() where T : Construction
        {
            return (T) Trigger.Construction;
        }

    }
}