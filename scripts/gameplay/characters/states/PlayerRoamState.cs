using Game.Core;
using Godot;
using System;

namespace Game.Gameplay
{
	public partial class PlayerRoamState : Node
	{
		[ExportCategory("State Vars")]
		[Export] public PlayerInput playerInput;

		public override void _Process(double delta)
		{
			GetInputDirection();
			GetInput(delta);
		}

		public void GetInputDirection()
		{
			if (Input.IsActionJustPressed("ui_up"))
			{
				playerInput.Direction = Vector2.Up;
				playerInput.TargePosition = new Vector2(0, -Globals.Instance.GRID_SIZE);
			}
			else if (Input.IsActionJustPressed("ui_down"))
			{
				playerInput.Direction = Vector2.Down;
				playerInput.TargePosition = new Vector2(0, Globals.Instance.GRID_SIZE);
			}
			else if (Input.IsActionJustPressed("ui_left"))
			{
				playerInput.Direction = Vector2.Left;
				playerInput.TargePosition = new Vector2(-Globals.Instance.GRID_SIZE, 0);
			}
			else if (Input.IsActionJustPressed("ui_right"))
			{
				playerInput.Direction = Vector2.Right;
				playerInput.TargePosition = new Vector2(Globals.Instance.GRID_SIZE, 0);
			}
		}

		public void GetInput(double delta)
		{
			if (Modules.IsActionJustReleased())
			{
				if (playerInput.HoldTime > playerInput.Holdthreshold)
				{
					playerInput.EmitSignal(CharacterInput.SignalName.Walk);
				}
				else
				{
					playerInput.EmitSignal(CharacterInput.SignalName.Turn);
				}
			}
			if(Modules.IsActionPressed())
			{
				playerInput.HoldTime += delta;
				
				if (playerInput.HoldTime > playerInput.Holdthreshold)
				{
					playerInput.EmitSignal(CharacterInput.SignalName.Walk);
				}
			}
		}

	}
}

