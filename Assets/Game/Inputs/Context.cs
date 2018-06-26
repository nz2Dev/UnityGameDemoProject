using System;
using Game.Utils;

namespace Game.Inputs
{
    public class Context
    {
        public Layer Layer { get; set; }
        public Type Type { get; set; }

        public Context()
        {
            Layer = Layer.Default;
        }
    }
}