using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public PlayerData data		   { get; set; }
	[Export] public Tools currentTool	   { get; set; }


    public Core core 					   { get; private set; }
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerInputHandler inputHandler { get; private set; }

    public AnimatedSprite2D anim 		   { get; private set; }
	public CharacterBody2D characterBody   { get; private set; }

    public override void _EnterTree()
	{
		if (data == null)
		{
			data = GD.Load<PlayerData>("res://assets/data/PlayerData.tres");
		}

        core = GetNode<Core>("./Core");
        anim = GetNode<AnimatedSprite2D>("./AnimatedSprite2D");
   		stateMachine = GetNode<PlayerStateMachine>("./StateMachine");
        inputHandler = GetNode<PlayerInputHandler>("./InputHandler");
    }

	public override void _Ready()
	{
        stateMachine.Initialize("IdleState");
	}
 
	public override void _Process(double delta)
	{   
		core.LogicUpdate(delta);
 		stateMachine.CurrentState.LogicUpdate(delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		stateMachine.CurrentState.PhysicsUpdate(delta);
	}

}
