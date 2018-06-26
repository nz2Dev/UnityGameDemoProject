using System.Linq;
using Game.Inputs;
using Game.Inputs.Triggers;
using Game.UI.Triggers.Processors;
using UnityEngine;

namespace Game.UI.Triggers
{
    [RequireComponent(typeof(ConstructionProcessorsFactory))]
    public class TriggersUI : MonoBehaviour
    {
        [SerializeField] TriggersHost triggersHost = null;
        [SerializeField] Activator[] activators = null;
        ConstructionProcessorsFactory factory;

        Trigger lastTrigger = null;
        Activator currentActivator = null;
        IConstructionProcessor currentProcessor = null;

        public TriggersHost CurrentHost
        {
            get { return triggersHost; }
        }

        void Start()
        {
            TriggersDefiner.ObserveChanges(triggersHost);
            factory = GetComponent<ConstructionProcessorsFactory>();
        }

        void Update()
        {
            if (currentActivator == null)
            {
                UpdateActivatorTargets();
                var active = activators.FirstOrDefault(activator => activator.IsActivated());
                if (active != null)
                {
                    var currentTrigger = active.AssignedTrigger;
                    if (lastTrigger != null)
                    {
                        lastTrigger.Unfocus();
                    }

                    currentProcessor = factory.CreateConstructionProcessor(this, currentTrigger.Construction);
                    currentProcessor.Init(currentTrigger);

                    currentActivator = active;
                }
            }
            else
            {
                currentProcessor.UpdateProcessor();
                if (currentProcessor.IsFinish(currentActivator))
                {
                    lastTrigger = currentActivator.AssignedTrigger;
                    currentProcessor.Destroy();
                    currentProcessor = null;
                    currentActivator = null;
                }   
            }
        }

        void UpdateActivatorTargets()
        {
            foreach (var activator in activators)
            {
                activator.AssignTrigger(triggersHost.GetTriggers());
            }
        }
    }
}