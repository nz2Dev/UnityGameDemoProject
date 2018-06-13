using UnityEngine;
using UnityEngine.AI;

namespace Game.Characters.Controllers
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (Character))]
    public class PathfindingCharacterControl : MonoBehaviour
    {
        Transform target;
        NavMeshAgent agent;
        Character character;

        void Start()
        {
            character = GetComponent<Character>();

            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        public void SetTarget(Transform target) {
            this.target = target;
        }

        void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
            }

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity);
            }
            else
            {
                character.Move(Vector3.zero);
            }
        }
    }
}
