using System;
using UnityEngine;

namespace Game.Characters.Extensions
{
    public interface IWeapon
    {
        event Action OnHitEvent;
        void PlayAttack(Transform transformTarget);
    }
}