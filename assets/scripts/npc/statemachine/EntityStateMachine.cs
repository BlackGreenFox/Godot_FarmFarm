using Godot;
using System;
using System.Collections.Generic;

public partial class EntityStateMachine : Node
{
    protected Dictionary<string, EntityState> states = new Dictionary<string, EntityState>();

    public EntityState CurrentState { get; private set; }
    public string CurrentStateName { get; private set; }
    public string PrevStateName { get; private set; }

    public override void _Ready()
    {
        Entity npc = GetParent() as Entity;

        foreach (Node node in GetChildren())
        {
            if (node is EntityState state)
            {
                states[node.Name] = state;

                state.stateMachine = this;
                state.core = npc.core;
                state.npc = npc;
            }

        }

        npc.anim.AnimationFinished += OnAnimationFinished;
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
            return;
        }

        CurrentState?.Exit();

        PrevStateName = CurrentStateName;
        CurrentStateName = newState;
        CurrentState = states[newState];

        CurrentState.Enter();
    }

    public void ExecuteStateLogic(double delta) => CurrentState.LogicUpdate(delta);
    public void ExecuteStatePhysics(double delta) => CurrentState.PhysicsUpdate(delta);
}
