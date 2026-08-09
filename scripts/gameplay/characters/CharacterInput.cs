using Godot;
using Game.Core;

namespace Game.Gameplay
{
	public abstract partial class CharacterInput : Node
	{
		[Signal] public delegate void WalkEventHandler();
		[Signal] public delegate void TurnEventHandler();

		[ExportCategory("Common Inputs")]
		[Export] public Vector2 Directoin = Vector2.Zero;
		[Export] public Vector2 TargePosition = Vector2.Zero;

	}
}
