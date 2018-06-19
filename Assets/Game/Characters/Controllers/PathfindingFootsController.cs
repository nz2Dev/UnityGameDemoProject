using Game.Characters.Extensions;
using Game.Characters.Extensions.Body;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Characters.Controllers
{
    [RequireComponent(typeof(Foots))]
    public class PathfindingFootsController : MonoBehaviour
    {
        const string PathfindingTargetName = "PathfindingTarget";

        public Sprite WalkIcon;

        Transform target;
        NavMeshAgent agent;
        Foots characterFoots;

        GameObject fakeTarget;

        void Start()
        {
            characterFoots = GetComponent<Foots>();
            
            agent = GetComponentInParent<Character>().GetComponent<NavMeshAgent>();
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
                characterFoots.Move(agent.desiredVelocity);
            }
            else
            {
                characterFoots.Move(Vector3.zero);

                if (fakeTarget != null)
                {
                    Destroy(fakeTarget);
                    fakeTarget = null;
                }
            }
        }
    }
}