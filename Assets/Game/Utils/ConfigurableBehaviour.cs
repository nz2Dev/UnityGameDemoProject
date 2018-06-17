using UnityEngine;

namespace Game.Utils
{
    public class ConfigurableBehaviour<TConfig> : MonoBehaviour where TConfig : BehaviourConfig
    {
        TConfig config;

        public MonoBehaviour SetConfig(TConfig configToSet)
        {
            config = configToSet;
            OnConfigChanged(config);
            return this;
        }

        protected virtual void OnConfigChanged(TConfig config)
        {
        }

        public TConfig GetConfig()
        {
            return config;
        }
    }
}