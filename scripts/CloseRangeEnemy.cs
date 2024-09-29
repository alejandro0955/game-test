using System;
using Godot;

public partial class CloseRangeEnemy : Enemy
{
    public Area2D Hitbox;

    public override void _Ready()
    {
        base._Ready();
        Hitbox = GetNode<Area2D>("Hitbox");
    }

    public override void _Process(double delta)
    {
        Hitbox.Set("KnockBackDirection", Velocity.Normalized());
    }
}
