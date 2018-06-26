using Game.Characters;
using Game.Characters.Extensions;
using Game.Utils;
using UnityEngine;

namespace Game.Combat.Abilityes
{
    public class TeleportAbility : BaseAbility<TeleportAbilityConfig>
    {
        Teleporter teleporter;

        void Start()
        {
            teleporter = GetComponentInChildren<Teleporter>();
        }

        public void Teleport(Vector3 point)
        {
            // if some condition was met only then do so (e.g has mana etc. or needs to move first to some position)
            // Or maybe after teleporting it will cause some damage.
            // But to actually deal with teleporting effect etc. we delegate this to Teleporter.
            teleporter.Teleport(point);
        }
    }
}