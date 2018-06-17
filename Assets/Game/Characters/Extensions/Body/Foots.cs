using UnityEngine;

namespace Game.Characters.Extensions.Body
{
    public class Foots : MonoBehaviour
    {
        static readonly Vector3 GroundNormal = Vector3.up;

        [SerializeField] float movingTurnSpeed = 360;
        [SerializeField] float stationaryTurnSpeed = 180;
        [SerializeField] float moveSpeedMultiplier = 1f;
        [SerializeField] float animSpeedMultiplier = 1f;

        Character character;
        Rigidbody characterRigidbody;
        Animator characterAnimator;

        float turnAmount;
        float forwardAmount;

        void Start()
        {
            character = GetComponentInParent<Character>();
            character.AnimatorEvent += HandleAnimatorMove;

            characterRigidbody = character.GetComponent<Rigidbody>();
            characterRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            characterAnimator = character.GetComponent<Animator>();
        }

        public void Move(Vector3 move)
        {
            if (move.magnitude > 1f)
                move.Normalize();
            
            move = character.transform.InverseTransformDirection(move);
            move = Vector3.ProjectOnPlane(move, GroundNormal);

            turnAmount = Mathf.Atan2(move.x, move.z);
            forwardAmount = move.z;

            ApplyExtraTurnRotation();
            UpdateAnimator(move);
        }

        void UpdateAnimator(Vector3 move)
        {
            characterAnimator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
            characterAnimator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);

            if (move.magnitude > 0)
            {
                characterAnimator.speed = animSpeedMultiplier;
            }
        }

        void ApplyExtraTurnRotation()
        {
            float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
            character.transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
        }

        void HandleAnimatorMove(Animator animator)
        {
            if (Time.deltaTime > 0)
            {
                var velocity = (animator.deltaPosition * moveSpeedMultiplier) / Time.deltaTime;
                velocity.y = characterRigidbody.velocity.y;
                characterRigidbody.velocity = velocity;
            }
        }
    }
}