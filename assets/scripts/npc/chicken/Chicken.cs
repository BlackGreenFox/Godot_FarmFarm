using Godot;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class Chicken : Entity
{
    [Export] public int health;
    [Export] public int speed;

    public EntityStateMachine stateMachine { get; private set; }

    public override void _EnterTree()
    {
        base._EnterTree();
        stateMachine = GetNode<EntityStateMachine>("./StateMachine");
    }


    public override void _Ready()
    {
        stateMachine.Initialize("IdleState");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        stateMachine.CurrentState.LogicUpdate(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        stateMachine.CurrentState.PhysicsUpdate(delta);
    }
}
