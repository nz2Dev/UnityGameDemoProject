using UnityEngine;

namespace Game.Utils
{
    public class ConfigurableBehaviour<TConfig> : MonoBehaviour where TConfig : BehaviourConfig
    {
        public TConfig Config { get; private set; }

        public MonoBehaviour SetConfig(TConfig configToSet)
        {
            Config = configToSet;
            OnConfigChanged(Config);
            return this;
        }

        protected virtual void OnConfigChanged(TConfig config)
        {
        }
    }
}