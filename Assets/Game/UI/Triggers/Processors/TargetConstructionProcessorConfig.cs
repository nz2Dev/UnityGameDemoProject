using Game.Inputs;
using Game.Inputs.Constructions;
using UnityEngine;

namespace Game.UI.Triggers.Processors
{
    [CreateAssetMenu(menuName = "ConstructionProcessor/Target")]
    public class TargetConstructionProcessorConfig : ConstructionProcessorConfig
    {
        [SerializeField] GameObject boundsPrefab = null;
        [SerializeField] GameObject selectorPrefab = null;
        [SerializeField] KeyCode finishKeyCode = KeyCode.Mouse0;
        [SerializeField] int selectorRadius = 1;

        public override bool IsProcess(Construction construction)
        {
            return construction is TargetConstruction;
        }

        public override IConstructionProcessor CreateProcessor(TriggersUI ui, Construction construction)
        {
            var processor = ui.gameObject.AddComponent<TargetConstructionProcessor>();
            processor.SetConfig(this);
            return processor;
        }

        public GameObject BoundsPrefab
        {
            get { return boundsPrefab; }
        }

        public GameObject SelectorPrefab
        {
            get { return selectorPrefab; }
        }

        public KeyCode FinishKeyCode
        {
            get { return finishKeyCode; }
        }

        public int SelectorRadius
        {
            get { return selectorRadius; }
        }
    }
}