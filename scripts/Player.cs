using System;
using Godot;

public partial class Player : Character
{
    public override void _Process(double delta)
    {
        Vector2 mouse_direction = GetGlobalMousePosition() - GlobalPosition.Normalized();
        if (mouse_direction.X > 0)
        {
            AnimatedSprite.FlipH = false;
        }
        else if (mouse_direction.X < 0 && !AnimatedSprite.FlipH)
        {
            AnimatedSprite.FlipH = true;
        }
    }

    public void get_input()
    {
        if (Input.IsActionPressed("ui_down"))
        {
            mov_direction += Vector2.Down;
        }
        if (Input.IsActionPressed("ui_up"))
        {
            mov_direction += Vector2.Up;
        }
        if (Input.IsActionPressed("ui_left"))
        {
            mov_direction += Vector2.Left;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            mov_direction += Vector2.Right;
        }
    }
}
