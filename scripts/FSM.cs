using System.ComponentModel;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Godot;
using Godot.Collections;

public partial class FSM : Node
{
    public Dictionary<string, int> States = new Dictionary<string, int> { };
    public int PreviousState = -1;
    public int State = -1;
    public Character parent;
    public AnimationPlayer AnimationPlayer;

    public override void _Ready()
    {
        parent = GetParent<Character>();
        GD.Print("Test" + parent);
    }

    public override void _PhysicsProcess(double delta)
    {
        GD.Print("test");
        if (State != -1)
        {
            StateLogic(delta);
            int transition = GetTransition();
            if (transition != 1)
            {
                SetState(transition);
            }
        }
    }

    public void StateLogic(double delta) { }

    public int GetTransition()
    {
        return -1;
    }

    public void AddState(string new_state)
    {
        States[new_state] = States.Count;
    }

    public void SetState(int NewState)
    {
        ExitState(State);
        PreviousState = State;
        State = NewState;
        EnterState(PreviousState, State);
    }

    public void EnterState(int _PreviousState, int _NewState) { }

    public void ExitState(double delta) { }
}
