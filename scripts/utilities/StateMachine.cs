using Godot;
using System;

namespace Game.Utilities
{
	public partial class StateMachine : Node
	{
		[ExportCategory("State Machiene Vars")]
		[Export] public Node Customer;
		[Export] public State Currentstate;

		public override void _Ready()
		{
			foreach (Node child in GetChildren())
			{
				if (child is State state)
				{
					state.StateOwner = Customer;
					state.SetProcess(false);
				}
			}
		}

		public void ChangeState(State newState)
		{
			Currentstate?.ExitState();
			Currentstate = newState;
			Currentstate?.ExitState();

			foreach (Node child in GetChildren())
			{
				if (child is State state)
				{
					state.SetProcess(child == Currentstate);
				}
			}
		}
	}
}
