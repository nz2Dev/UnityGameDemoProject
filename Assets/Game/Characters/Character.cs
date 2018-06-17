using System;
using System.Linq;
using UnityEngine;

namespace Game.Characters
{
    [RequireComponent(typeof(Animator))]
    public class Character : MonoBehaviour
    {
        public event Action<Animator> AnimatorEvent;
        public event Action<AnimationEvent> AnimationEvent;

        Animator animator;
        
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void OnAnimationEvent(AnimationEvent animationEvent)
        {
            if (AnimationEvent != null)
            {
                AnimationEvent(animationEvent);
            }
        }

        void OnAnimatorMove()
        {
            if (AnimatorEvent != null)
            {
                AnimatorEvent(animator);
            }
        }

        public Transform FindPart(Part part) {
            return GetComponentsInChildren<PartSocket>()
                .First(socket => socket.GetPart() == part)
                .transform;
        }
    }
}