using System;
using UnityEngine;

namespace Game.Characters.Extensions.Swords
{
    [RequireComponent(typeof(BoxCollider))]
    public class OneHandSword : MonoBehaviour
    {
        public event Action OnHitEvent;

        Character character;

        void Start()
        {
            character = GetComponentInParent<Character>();
        }

        public void PlayAttack(Transform go)
        {
            character.GetComponent<Animator>().SetTrigger("Attack");
            if (OnHitEvent != null)
            {
                OnHitEvent();
            }
        }
    }
}