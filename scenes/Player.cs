using System;
using Godot;

public partial class Player : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.

	public override void _Ready() { }

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void _Process(double delta)
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		var up = Input.IsKeyPressed(Key.W);
		var left = Input.IsKeyPressed(Key.A);
		var down = Input.IsKeyPressed(Key.S);
		var right = Input.IsKeyPressed(Key.D);
		var baseSpeed = 1;

		if (up)
		{
			Position += new Vector2(0, -baseSpeed);
			animatedSprite2D.Play("walking");
		}
		if (down)
		{
			Position += new Vector2(0, baseSpeed);
			animatedSprite2D.Play("walking");
		}
		if (left)
		{
			animatedSprite2D.FlipH = true;
			Position += new Vector2(-baseSpeed, 0);
			animatedSprite2D.Play("walking");
		}
		if (right)
		{
			animatedSprite2D.FlipH = false;
			Position += new Vector2(baseSpeed, 0);
			animatedSprite2D.Play("walking");
		}
		if (!up && !down && !right && !left)
		{
			animatedSprite2D.Play("idle");
		}

		// if (this.Velocity == new Vector2(0, 0))
		// {
		// 	animatedSprite2D.Stop();
		// }
	}
}
