using Godot;
using System;
using System.IO;

public partial class ChickenMoveState : EntityState
{
    [Export] public float moveMaxTime = 60f;
    [Export] public float moveMinTime = 20f;
    private Vector2 dir;

    private Timer _timer;

    protected Chicken chicken => npc as Chicken;

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        dir = new Vector2(
    (float)GD.RandRange(-1f, 1f),
    (float)GD.RandRange(-1f, 1f)
   ).Normalized();

        baseAnimationName = "walk";
        base.Enter();

        _timer = new Timer();
        AddChild(_timer);

        _timer.WaitTime = 1.0f;
        _timer.OneShot = false;
        _timer.WaitTime = (float)GD.RandRange(moveMinTime, moveMaxTime);
        _timer.Timeout += OnTimerTimeout;
        _timer.Start();
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



        core.Movement.SetVelocity(chicken.speed, dir);

        if (!isExitingState)
        {

        }

        PlayAnimation();
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
    }

    private void OnTimerTimeout()
    {
        if (!isExitingState)
        {
            stateMachine.ChangeState("IdleState");
        }
    }
}
