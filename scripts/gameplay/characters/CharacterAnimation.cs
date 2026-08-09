using Game.Core;
using Godot;
using System;
using System.Collections;

namespace Game.Gameplay
{
	public partial class CharacterAnimation : AnimatedSprite2D
	{
		[ExportCategory("Nodes")]
		[Export] public CharacterInput characterInput;
		[Export] public CharacterMovement chracterMovement;

		[ExportCategory("Animations Vars")]
		[Export] public ECharacterAnimation ECharacterAnimation = ECharacterAnimation.idle_down;

		public override void _Ready()
		{
			GameLogger.Info("Loading player animation component ...");
		}

		public void PlayAnimation(string animationType)
		{
			ECharacterAnimation previousAnimation = ECharacterAnimation;

			if (chracterMovement.IsMoving()) return;
			switch (animationType)
			{
				case "walk":
					if (characterInput.Directoin == Vector2.Up)
					{
						ECharacterAnimation = ECharacterAnimation.walk_up;
					}
					else if (characterInput.Directoin == Vector2.Down)
					{
						ECharacterAnimation = ECharacterAnimation.walk_down;
					}
					else if (characterInput.Directoin == Vector2.Right)
					{
						ECharacterAnimation = ECharacterAnimation.walk_righ;
					}
					else if (characterInput.Directoin == Vector2.Left)
					{
						ECharacterAnimation = ECharacterAnimation.walk_left;
					}
					break;
				case "turn":
					if (characterInput.Directoin == Vector2.Up)
					{
						ECharacterAnimation = ECharacterAnimation.turn_up;
					}
					else if (characterInput.Directoin == Vector2.Down)
					{
						ECharacterAnimation = ECharacterAnimation.turn_down;
					}
					else if (characterInput.Directoin == Vector2.Right)
					{
						ECharacterAnimation = ECharacterAnimation.turn_righ;
					}
					else if (characterInput.Directoin == Vector2.Left)
					{
						ECharacterAnimation = ECharacterAnimation.turn_left;
					}
					break;
				case "idle":
					if (characterInput.Directoin == Vector2.Up)
					{
						ECharacterAnimation = ECharacterAnimation.idle_up;
					}
					else if (characterInput.Directoin == Vector2.Down)
					{
						ECharacterAnimation = ECharacterAnimation.idle_down;
					}
					else if (characterInput.Directoin == Vector2.Right)
					{
						ECharacterAnimation = ECharacterAnimation.idle_righ;
					}
					else if (characterInput.Directoin == Vector2.Left)
					{
						ECharacterAnimation = ECharacterAnimation.idle_left;
					}
					break;
			}
			if (previousAnimation != ECharacterAnimation)
			{
				GameLogger.Info($"Playing animatoin {ECharacterAnimation}");
				Play(ECharacterAnimation.ToString());
			} 
		}
	}
}
