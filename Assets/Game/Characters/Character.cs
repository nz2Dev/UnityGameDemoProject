using UnityEngine;

namespace Game.Characters
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(Animator))]
	public class ThirdPersonCharacter : MonoBehaviour
	{
	    public readonly Vector3 GroundNormal = Vector3.up;

        [SerializeField] float movingTurnSpeed = 360;
		[SerializeField] float stationaryTurnSpeed = 180;
		[SerializeField] float moveSpeedMultiplier = 1f;
		[SerializeField] float animSpeedMultiplier = 1f;
		
		Rigidbody rigidbodY;
		Animator animator;
		float turnAmount;
		float forwardAmount;

		void Start()
		{
			animator = GetComponent<Animator>();

			rigidbodY = GetComponent<Rigidbody>();
			rigidbodY.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}


		public void Move(Vector3 move)
		{

			// convert the world relative moveInput vector into a local-relative
			// turn amount and forward amount required to head in the desired
			// direction.
		    if (move.magnitude > 1f)
		    {
		        move.Normalize();
		    }
			move = transform.InverseTransformDirection(move);
			move = Vector3.ProjectOnPlane(move, GroundNormal);
			turnAmount = Mathf.Atan2(move.x, move.z);
			forwardAmount = move.z;

			ApplyExtraTurnRotation();
			UpdateAnimator(move);
		}

		void UpdateAnimator(Vector3 move)
		{
			animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
			animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);

			// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
			// which affects the movement speed because of the root motion.
			if (move.magnitude > 0)
			{
				animator.speed = animSpeedMultiplier;
			}
		}


		void ApplyExtraTurnRotation()
		{
			// help the character turn faster (this is in addition to root rotation in the animation)
			float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
			transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
		}


		public void OnAnimatorMove()
		{
			// we implement this function to override the default root motion.
			// this allows us to modify the positional speed before it's applied.
			if (Time.deltaTime > 0)
			{
				Vector3 v = (animator.deltaPosition * moveSpeedMultiplier) / Time.deltaTime;

				// we preserve the existing y part of the current velocity.
				v.y = rigidbodY.velocity.y;
				rigidbodY.velocity = v;
			}
		}
	}
}
