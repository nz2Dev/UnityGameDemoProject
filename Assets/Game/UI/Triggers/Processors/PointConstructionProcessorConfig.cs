using Game.Inputs;
using Game.Inputs.Constructions;
using UnityEngine;

namespace Game.UI.Triggers.Processors
{
    [CreateAssetMenu(menuName = "ConstructionProcessor/Point")]
    public class PointConstructionProcessorConfig : ConstructionProcessorConfig
    {
        [SerializeField] GameObject pointGraphicPrefab = null;
        [SerializeField] KeyCode triggerKeyCode = KeyCode.Mouse0;
        [SerializeField] KeyCode finishKeyCode = KeyCode.Mouse0;

        public override bool IsProcess(Construction abilityConstruction)
        {
            return abilityConstruction is PointConstruction;
        }

        public override IConstructionProcessor CreateProcessor(TriggersUI ui, Construction construction)
        {
            var processor = ui.gameObject.AddComponent<PointConstructionProcessor>();
            processor.SetConfig(this);
            return processor;
        }

        public GameObject GetPointGraphicPrefab()
        {
            return pointGraphicPrefab;
        }

        public KeyCode GetTriggerKeyCode()
        {
            return triggerKeyCode;
        }

        public KeyCode GetFinishKeyCode()
        {
            return finishKeyCode;
        }
    }
}