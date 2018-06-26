using Game.Inputs;
using Game.Inputs.Constructions;
using Game.Utils;
using UnityEngine;

namespace Game.UI.Triggers.Processors
{
    public class PointConstructionProcessor : BaseConstructionProcessor<PointConstructionProcessorConfig>
    {
        GameObject indicator;

        protected override void OnInitTrigger()
        {
            indicator = Instantiate(Config.GetPointGraphicPrefab());
            SetIndicatorPosition();
        }

        public override void UpdateProcessor()
        {
            SetIndicatorPosition();
            if (Input.GetKeyUp(Config.GetTriggerKeyCode()))
            {
                Trigger.OnTrigger(new Inputs.Event
                {
                    GameObject = null,
                    Point = indicator.transform.position
                });
            }
        }

        public override bool IsFinish(Activator activator)
        {
            // TODO but is possible that one of processor will whant to finish only
            // when activator returns false from IsDeactivate() method or whatever else
            return activator.IsDeactivate() || Input.GetKeyUp(Config.GetFinishKeyCode());
        }

        public override void Destroy()
        {
            Destroy(indicator);
            Destroy(this);
        }

        void SetIndicatorPosition()
        {
            var position = CameraHelper.WalkablePoint();
            if (!position.Equals(Vector3.negativeInfinity))
            {
                indicator.transform.position = position;
            }
        }
    }
}