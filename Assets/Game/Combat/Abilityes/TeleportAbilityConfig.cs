using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    [CreateAssetMenu(menuName = "Ability/Teleport")]
    public class TeleportAbilityConfig : BaseAbilityConfig
    {
        public override MonoBehaviour AttachTo(GameObject gameObject)
        {
            return gameObject.AddComponent<TeleportAbility>().SetConfig(this);
        }
    }
}