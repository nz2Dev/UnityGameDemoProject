using Boo.Lang.Runtime;
using Game.Inputs;
using Game.UI.Triggers.Processors;
using UnityEngine;

namespace Game.UI.Triggers
{
    public class ConstructionProcessorsFactory : MonoBehaviour
    {
        [SerializeField] ConstructionProcessorConfig[] configs = null;

        void Start()
        {
            if (configs == null)
            {
                Debug.LogError("configs are empty");
            }
        }

        public IConstructionProcessor CreateConstructionProcessor(TriggersUI ui, Construction construction)
        {
            ConstructionProcessorConfig selectedConfig = null;
            foreach (var config in configs)
            {
                if (config.IsProcess(construction))
                {
                    if (selectedConfig != null)
                    {
                        Debug.LogError("there are more than one processor for: " + construction +
                                       " first one is: " + selectedConfig + " and next one is: " + config);
                    }
                    selectedConfig = config;
                }
            }

            if (selectedConfig == null)
            {
                throw new RuntimeException("There was any processor for construction: " + construction);
            }

            return selectedConfig.CreateProcessor(ui, construction);
        }
    }
}