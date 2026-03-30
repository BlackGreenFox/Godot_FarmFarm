using Godot;
using System;
using System.Collections.Generic;
using static Godot.WebSocketPeer;

public partial class PlayerStateMachine : Node
{
	
	protected Dictionary<string, PlayerState> states = new Dictionary<string, PlayerState>();

	public PlayerState CurrentState { get; private set; }
	public string CurrentStateName { get; private set; }
	public string PrevStateName { get; private set; }

	public override void _Ready()
	{
		Player player = GetParent() as Player;

		foreach (Node node in GetChildren())
		{
			if (node is PlayerState state) {
				states[node.Name] = state;

                state.stateMachine = this;
                state.core = player.core;
                state.player = player;

                GD.Print($"Registered state: {node.Name}");
            }
		
		}

        player.anim.AnimationFinished += OnAnimationFinished;
    }

    private void OnAnimationFinished()
    {
        CurrentState?.OnAnimationFinished();
    }

    public void Initialize(string startingState)
	{
        if (!states.ContainsKey(startingState))
        {
            GD.PushError($"State {startingState} not found!");
            return;
        }
        
		CurrentState = states[startingState];
		CurrentStateName = startingState;
		CurrentState.Enter();
	}

	public void ChangeState(string newState)
	{
        if (CurrentStateName == newState)
            return;

        if (!states.ContainsKey(newState))
        {
            GD.PushError($"State {newState} not found!");
            return;
        }
        
		GD.Print("Trying:", newState);
        CurrentState?.Exit();

        PrevStateName = CurrentStateName;
        CurrentStateName = newState;
        CurrentState = states[newState];

        GD.Print($"State changed: {PrevStateName} → {CurrentStateName}");

        CurrentState.Enter();
    }

	public void ExecuteStateLogic(double delta) => CurrentState.LogicUpdate(delta);
	public void ExecuteStatePhysics(double delta) => CurrentState.PhysicsUpdate(delta);
}
