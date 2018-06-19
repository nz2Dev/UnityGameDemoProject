using Game.Inputs;
using UnityEngine;

namespace Game.UI.Triggers.Processors
{
    public abstract class ConstructionProcessorConfig : ScriptableObject
    {
        public abstract bool IsProcess(Construction construction);
        public abstract IConstructionProcessor CreateProcessor(TriggersUI ui, Construction construction);
    }
}