using Godot;
using System;

public partial class PlayerAxeState : PlayerToolState
{
    [Export] CollisionShape2D hit_component_shape { get; set; }

    public override void DoCheck()
    {
        base.DoCheck();

    }

    public override void _Ready()
    {
        hit_component_shape.Disabled = true;
        hit_component_shape.Position = Vector2.Zero;
    }

    public override void Enter()
    {
        baseAnimationName = "chopping";
        base.Enter();
        core.Movement.SetVelosityZero();


        hit_component_shape.Disabled = false;
        if (core.Movement.FacingDirection == Vector2.Up)
        {
            hit_component_shape.Position = new Vector2(0, -14);
        }
        else if (core.Movement.FacingDirection == Vector2.Left)
        {
            hit_component_shape.Position = new Vector2(-14, 0);
        }
        else if (core.Movement.FacingDirection == Vector2.Right)
        {
            hit_component_shape.Position = new Vector2(14, 0);
        }
        else
        {
            hit_component_shape.Position = new Vector2(0, 14);
        }

    }

    public override void Exit()
    {
        base.Exit();
        hit_component_shape.Disabled = true;
    }

    public override void LogicUpdate(double delta)
    {
        base.LogicUpdate(delta);

        if (isExitingState)
        {
            stateMachine.ChangeState("IdleState");
        }
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
    }

    public override void OnAnimationFinished()
    {
        base.OnAnimationFinished();
        stateMachine.ChangeState("IdleState");
    }
}
