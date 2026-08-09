using Game.Core;
using Godot;

namespace Game.Utilities
{
    public abstract partial class State : Node
    {
        [Export] public Node StateOwner;

        public virtual void EnterState()
        {
            GameLogger.Info($"Entering {GetType().Name} ...");
        }

        public virtual void ExitState()
        {
             GameLogger.Info($"Exiting {GetType().Name} ...");
        }
    }
}