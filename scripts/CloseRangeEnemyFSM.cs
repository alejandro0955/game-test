using System;
using Godot;

public partial class CloseRangeEnemyFSM : FSM
{
    public CloseRangeEnemyFSM()
    {
        AddState("Chase");
    }

    public override void _Ready()
    {
        parent = GetParent<Character>();
        AnimationPlayer = parent.GetNode<AnimationPlayer>("AnimationPlayer");
        SetState(States["Chase"]);
    }

    public override void StateLogic(double delta)
    {
        if (State == States["Chase"])
        {
            parent.Call("Chase");
            parent.Call("Move");
        }
    }

    public override int GetTransition()
    {
        return -1;
    }

    public override void EnterState(int _PreviousState, int _NewState)
    {
        switch (_NewState)
        {
            case 0:
                AnimationPlayer.Play("walk");
                break;
        }
    }
}
