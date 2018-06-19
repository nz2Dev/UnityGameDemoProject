using Game.Inputs;

namespace Game.UI.Triggers
{
    public interface IConstructionProcessor
    {
        void Init(Trigger trigger);

        // Its needed because we decoupled finishing conditon from triggering conditon.
        // And there can potentialy exist situation when triggering code will not be called due to 
        // not in time destroy call.
        void UpdateProcessor();

        bool IsFinish(Activator activator);
        void Destroy();
    }
}