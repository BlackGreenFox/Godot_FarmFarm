using Godot;
using System;

public partial class Player : Entity
{
    [Export] public PlayerData data		   { get; set; }
	[Export] public Tools currentTool	   { get; set; }

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }


    public override void _EnterTree()
	{
        base._EnterTree();
        if (data == null)
		{
			data = GD.Load<PlayerData>("res://assets/data/PlayerData.tres");
		}

   		stateMachine = GetNode<PlayerStateMachine>("./StateMachine");
        inputHandler = GetNode<PlayerInputHandler>("./InputHandler");
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
