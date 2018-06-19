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
            OnInit();
        }

        protected virtual void OnInit()
        {            
        }

        public virtual void UpdateProcessor()
        {
        }

        public abstract bool IsFinish(Activator activator);

        public virtual void Destroy()
        {
        }

    }
}