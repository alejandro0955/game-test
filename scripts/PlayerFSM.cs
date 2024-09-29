using Godot;

public partial class PlayerFSM : FSM
{
    public PlayerFSM()
    {
        AddState("Idle");
        AddState("Move");
        AddState("Hurt");
        AddState("Dead");
    }

    public override void _Ready()
    {
        base._Ready();
        SetState(States["Idle"]);
    }

    public override void StateLogic(double delta)
    {
        if (State == States["Idle"] || State == States["Move"])
        {
            parent.Call("get_input");
            parent.Call("Move");
        }
    }

    public override int GetTransition()
    {
        switch (State)
        {
            case 0:
                if (parent.Velocity.Length() > 10)
                {
                    return States["Move"];
                }
                break;
            case 1:
                if (parent.Velocity.Length() < 10)
                {
                    return States["Idle"];
                }
                break;
            case 2:
                if (!AnimationPlayer.IsPlaying())
                {
                    return States["Idle"];
                }
                break;
        }
        return -1;
    }

    public override void EnterState(int _PreviousState, int _NewState)
    {
        switch (_NewState)
        {
            case 0:
                AnimationPlayer.Play("idle");
                break;
            case 1:
                AnimationPlayer.Play("walking");
                break;
            case 2:
                AnimationPlayer.Play("hurt");
                break;
            case 3:
                AnimationPlayer.Play("dead");
                break;
        }
    }
}
