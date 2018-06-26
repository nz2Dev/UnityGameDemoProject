using Game.Combat;

namespace Game.Inputs.Contexts
{
    public class MemberContext : Context
    {
        public MemberContext()
        {
            Layer = Utils.Layer.Combat;
            Type = typeof(CombatMember);
        }
    }
}