using Game.Inputs;
using Game.Inputs.Constructions;
using Game.Utils;
using UnityEngine;

namespace Game.UI.Triggers.Processors
{
    public class TargetConstructionProcessor : BaseConstructionProcessor<TargetConstructionProcessorConfig>
    {
        Transform playerTransform;
        Vector3 raycastedPoint;
        Transform currentTarget;

        GameObject boundsSprite;
        GameObject selectorSprite;

        void Awake()
        {
            playerTransform = GetComponent<TriggersUI>().CurrentHost.transform;
        }

        protected override void OnInitTrigger()
        {
            var construction = GetConstructionAs<TargetConstruction>();

            boundsSprite = Instantiate(Config.BoundsPrefab, playerTransform);
            boundsSprite.transform.localScale = new Vector3(construction.Radius, 1, construction.Radius);

            selectorSprite = Instantiate(Config.SelectorPrefab);
            UpdateTarget();
        }

        public override void UpdateProcessor()
        {
            UpdateTarget();
        }

        void UpdateTarget()
        {
            raycastedPoint = CameraHelper.WalkablePoint();
            if (raycastedPoint.Equals(Vector3.negativeInfinity))
            {
                return;
            }

            var nextTarget = CameraUtils.RaycastOnlyType(Trigger.Context.Type, 1 << (int) Trigger.Context.Layer);
            if (nextTarget && nextTarget.transform == playerTransform)
            {
                nextTarget = null;
            }
            else if (!nextTarget)
            {
                nextTarget = PhysicsUtils.NearestCollider(
                    raycastedPoint,
                    Config.SelectorRadius,
                    target => target.GetComponent(Trigger.Context.Type) && target.transform != playerTransform,
                    1 << (int) Trigger.Context.Layer
                );
            }

            if (nextTarget)
            {
                if (nextTarget != currentTarget)
                {
                    SelectTarget(nextTarget.transform);
                }
            }
            else if (currentTarget)
            {
                UnselectTarget();
            }

            if (!currentTarget)
            {
                selectorSprite.transform.position = raycastedPoint;
            }

            if (Input.GetKeyUp(Config.FinishKeyCode))
            {
                if (nextTarget)
                {
                    Trigger.OnTrigger(new Inputs.Event
                    {
                        GameObject = nextTarget.gameObject,
                        Point = Vector3.zero
                    });
                }
            }
        }

        public override bool IsFinish(Activator activator)
        {
            return base.IsFinish(activator) || Input.GetKeyUp(Config.FinishKeyCode);
        }

        public override void Destroy()
        {
            Destroy(boundsSprite);
            Destroy(selectorSprite);
            Destroy(this);
        }

        void UnselectTarget()
        {
            currentTarget = null;
            selectorSprite.transform.parent = null;
            selectorSprite.transform.localScale = Vector3.one;
        }

        void SelectTarget(Transform target)
        {
            currentTarget = target;

            selectorSprite.transform.parent = target.transform;
            selectorSprite.transform.localPosition = Vector3.zero;

            float radius = target.GetComponent<CapsuleCollider>().radius * 1.5f;
            selectorSprite.transform.localScale = new Vector3(radius, 1, radius);
        }
    }
}