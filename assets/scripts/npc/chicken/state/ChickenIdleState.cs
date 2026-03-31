using Godot;
using System;
using System.Collections.Generic;

public partial class ChickenIdleState : EntityState
{
    [Export] public float idleMaxTime = 6f;
    [Export] public float idleMinTime = 2f;

    private Timer _timer;

    public override void Enter()
    {
        _timer = new Timer();
        AddChild(_timer);

        _timer.WaitTime = 1.0f;
        _timer.OneShot = false;
        _timer.WaitTime = (float)GD.RandRange(idleMinTime, idleMaxTime);
        _timer.Start();
        _timer.Timeout += OnTimerTimeout;

        baseAnimationName = "idle";
        base.Enter();
        core.Movement.SetVelosityZero();
    }

    private void OnTimerTimeout()
    {
        if (!isExitingState)
        {
            stateMachine.ChangeState("MoveState");
        }
    }

    public override void Exit()
    {
        base.Exit();

        if (_timer != null)
        {
            _timer.Timeout -= OnTimerTimeout;
            _timer.QueueFree();
        }
    }

    public override void LogicUpdate(double delta)
    {
        base.LogicUpdate(delta);
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
    }
}
