using UnityEngine;
using UnityEngine.AI;

namespace Game.Characters.Controllers
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Character))]
    public class PathfindingCharacterControl : MonoBehaviour
    {
        const string PathfindingTargetName = "PathfindingTarget";

        Transform target;
        NavMeshAgent agent;
        Character character;

        GameObject fakeTarget;

        void Start()
        {
            character = GetComponent<Character>();

            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        public void Walk(Vector3 point)
        {
            fakeTarget = new GameObject(PathfindingTargetName);
            fakeTarget.transform.position = point;
            Follow(fakeTarget.transform);
        }

        public void Follow(Transform target)
        {
            this.target = target;
        }

        void Update()
        {
            if (target != null && target != fakeTarget)
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

                if (fakeTarget != null)
                {
                    Destroy(fakeTarget);
                    fakeTarget = null;
                }
            }
        }
    }
}