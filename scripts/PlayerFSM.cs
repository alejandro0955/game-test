using Godot;

public partial class PlayerFSM : FSM
{
    public PlayerFSM()
    {
        AddState("idle");
        AddState("move");
    }

    public override void _Ready()
    {
        parent = GetParent<Character>();
        AnimationPlayer = parent.GetNode<AnimationPlayer>("AnimationPlayer");
        SetState(States["idle"]);
    }

    public override void StateLogic(double delta)
    {
        parent.Call("get_input");
        parent.Call("move");
    }

    public override int GetTransition()
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
        }
    }
}
