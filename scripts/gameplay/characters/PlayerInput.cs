using Godot;
using Game.Core;

namespace Game.Gameplay
{
	public partial class PlayerInput : CharacterInput
	{
		[ExportCategory("Player Input")]
		[Export] public double Holdthreshold = 0.1f;
		[Export] public double HoldTime = 0.0f;
		public override void _Ready()
		{
			GameLogger.Info("Loading player input component ...");
		}
	}
}
