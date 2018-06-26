using Game.Utils;

namespace Game.Combat.Abilityes
{
    public class BaseAbility<TConfig> : ConfigurableBehaviour<TConfig>, IAbility where TConfig : BehaviourConfig
    {
        public virtual void Stop()
        {
        }
    }
}