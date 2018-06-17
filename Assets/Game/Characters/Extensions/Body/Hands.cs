using System;
using UnityEngine;

namespace Game.Characters.Extensions.Body
{
    public class Hands : MonoBehaviour, IWeapon
    {
        public event Action OnHitEvent;

        public void PlayAttack(Transform transformTarget)
        {
            print("Playing special attach animation and effect for hands");
            if (OnHitEvent != null)
            {
                OnHitEvent();
            }
        }
    }
}