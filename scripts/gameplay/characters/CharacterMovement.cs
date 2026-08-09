using Game.Core;
using Godot;
using System;

namespace Game.Gameplay
{

	public partial class CharacterMovement : Node
	{
		[Signal] public delegate void AnimationEventHandler();

		[ExportCategory("Nodes")]
		[Export] public Node2D Character;
		[Export] public CharacterInput CharacterInput;

		[ExportCategory("Movement")]
		[Export] public Vector2 TargetPosition = Vector2.Down;
		[Export] public bool IsWalking = false;

		public override void _Ready()
		{
			GameLogger.Info("Loading player movement component ...");
		}

		public override void _Process(double delta)
		{
		}

		public bool IsMoving ()
		{
			return IsWalking;
		}

		public void StartWalking()
		{
			if (!IsMoving())
			{
				//TODO: Movement Animatoin
				TargetPosition = Character.Position + CharacterInput.Directoin *Globals.Instance.GRID_SIZE;
				GameLogger.Info($"Moving from {Character.Position} to {TargetPosition}s");
				IsWalking = true;
			}
			else
			{
				//TODO: Idle Animation
			}
		}
		
		public void Walk (double delta)
		{
			if (IsWalking)
			{
				Character.Position = Character.Position.MoveToward(TargetPosition, (float)delta * Globals.Instance.GRID_SIZE *4);

				if (Character.Position.DistanceTo(TargetPosition) < 1f)
				{
					StopWalking();
				}
				else
				{
					//TODO: Idle Animation
				}
			}
		}

		public void StopWalking()
		{
			IsWalking = false;
			SnapPositoinToGrid();
		}

		public void turn()
		{
			//TODO: Turn Animaion
		}

		public void SnapPositoinToGrid()
		{
			Character.Position = new Vector2(
				Mathf.Round(Character.Position.X / Globals.Instance.GRID_SIZE) *Globals.Instance.GRID_SIZE,
				Mathf.Round(Character.Position.Y / Globals.Instance.GRID_SIZE) *Globals.Instance.GRID_SIZE
			);
		}
	}
}