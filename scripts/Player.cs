using System;
using System.ComponentModel;
using Godot;

public partial class Player : Character
{
    public Node2D Sword;
    public Area2D SwordHitbox;
    public AnimationPlayer SwordAnimationPlayer;

    public override void _Ready()
    {
        base._Ready();
        Sword = GetNode<Node2D>("Sword");
        SwordHitbox = GetNode<Area2D>("Sword/Node2D/Sprite2D/Hitbox");
        SwordAnimationPlayer = Sword.GetNode<AnimationPlayer>("SwordAnimationPlayer");
    }

    public override void _Process(double delta)
    {
        Vector2 mouse_direction = (GetGlobalMousePosition() - GlobalPosition).Normalized();
        if (mouse_direction.X > 0)
        {
            AnimatedSprite.FlipH = false;
        }
        else if (mouse_direction.X < 0 && !AnimatedSprite.FlipH)
        {
            AnimatedSprite.FlipH = true;
        }
        Sword.Rotation = mouse_direction.Angle();
        SwordHitbox.Set("KnockBackDirection", mouse_direction);
        if (Sword.Scale.Y == 1 && mouse_direction.X < 0)
        {
            Sword.Scale = new Vector2(Sword.Scale.X, -1);
        }
        else if (Sword.Scale.Y == -1 && mouse_direction.X > 0)
        {
            Sword.Scale = new Vector2(Sword.Scale.X, 1);
        }
    }

    public void get_input()
    {
        mov_direction = Vector2.Zero;
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
        if (Input.IsActionJustPressed("ui_attack") && !SwordAnimationPlayer.IsPlaying())
        {
            SwordAnimationPlayer.Play("Attack");
        }
    }
}
