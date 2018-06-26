using System;
using UnityEngine;

namespace Game.Characters.Extensions
{
    [RequireComponent(typeof(BoxCollider))]
    public class OneHandSword : MonoBehaviour, IWeapon
    {
        public event Action OnHitEvent;

        [SerializeField] int attackAnimType;

        Character character;

        void Start()
        {
            character = GetComponentInParent<Character>();
        }

        public void PlayAttack(Transform go)
        {
            print("Playing attack in OneHandSword");
            var animator = character.GetComponent<Animator>();
            animator.SetInteger("AttackType", attackAnimType);
            animator.SetTrigger("Attack");
        }

//        void OnAnimEvent()
//        {
//            if ("event" == "hit")
//            {
//                OnHit();
//            }
//        }

//        void OnColliderTriggered()
//        {
//            OnHit();
//        }

        void OnHit()
        {
            // play particle
            // play sounds FX
            // etc...
            if (OnHitEvent != null) {
                OnHitEvent();
            }
        }
    }
}