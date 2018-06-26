using System;
using UnityEngine;

namespace Game.Characters.Extensions
{
    public interface IWeapon
    {
        event Action OnHitEvent;
        void PlayAttack(Transform transformTarget);
    }

    public enum Attack {
        Hands = 0,
        Sword = 1,
        Bow = 2
    }
}