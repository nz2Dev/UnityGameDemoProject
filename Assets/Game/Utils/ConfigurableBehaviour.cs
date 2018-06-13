using UnityEngine;

namespace Game.Utils
{
    public class ConfigurableBehaviour<TConfig> : MonoBehaviour where TConfig : BehaviourConfig
    {
        TConfig config;

        public MonoBehaviour SetConfig(TConfig configToSet)
        {
            config = configToSet;
            return this;
        }

        public TConfig GetConfig()
        {
            return config;
        }
    }
}