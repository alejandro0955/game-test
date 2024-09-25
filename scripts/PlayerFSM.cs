using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Godot;
using Godot.Collections;

public partial class PlayerFSM : FSM
{
    public PlayerFSM()
    {
        AddState("idle");
        AddState("move");
    }

    public override void _Ready()
    {
        SetState(States["idle"]);
        var parent = GetParent<Character>();
    }

    public new void StateLogic(double delta)
    {
        parent.Call("get_input");
        parent.Call("move");
        GD.Print("tt");
    }

    public new int GetTransition()
    {
        switch (State)
        {
            case 0:
                if (parent.Velocity.Length() > 10)
                {
                    return States["move"];
                }
                break;
            case 1:
                if (parent.Velocity.Length() < 10)
                {
                    return States["idle"];
                }
                break;
        }
        return -1;
    }

    // public new void EnterState(int _PreviousState, int _NewState) { }
}
