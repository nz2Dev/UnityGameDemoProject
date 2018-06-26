using UnityEngine;
using UnityEngine.AI;

namespace Game.Characters.Extensions
{
    [RequireComponent(typeof(Humanoid))]
    public class HumanoidPathfinder : MonoBehaviour
    {
        const string PathfindingTargetName = "PathfindingTarget";

        public Sprite WalkIcon;

        Transform target;
        NavMeshAgent agent;
        Humanoid characterHumanoid;

        GameObject fakeTarget;

        void Start()
        {
            characterHumanoid = GetComponent<Humanoid>();
            
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
            if (target)
            {
                enabled = true;
            }
        }

//        public void Pause(bool pause)
//        {
            // TODO if toggleing enable woun't work
//        }

        void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
            }

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                characterHumanoid.Move(agent.desiredVelocity);
            }
            else
            {
                characterHumanoid.Move(Vector3.zero);

                if (fakeTarget != null)
                {
                    Destroy(fakeTarget);
                    fakeTarget = null;
                }
            }
        }

        public bool IsFollow(Transform transform)
        {
            return target != null || fakeTarget != null;
        }

        public bool IsWalk(Vector3 point)
        {
            return fakeTarget != null && fakeTarget.transform.position.Equals(point);
        }
    }
}