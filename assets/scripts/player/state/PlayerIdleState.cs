using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
	public override void Enter()
    {
        baseAnimationName = "idle";
        base.Enter();
        core.Movement.SetVelosityZero();
    }

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate(double delta)
	{
		base.LogicUpdate(delta);
		
		if (!isExitingState)
		{
            if (player.inputHandler.Direction != Vector2.Zero)
            {
				stateMachine.ChangeState("MoveState");
			}
            if (player.inputHandler.OnToolInput)
            {
                stateMachine.ChangeState("ToolState");
            }
        }
    }

	public override void PhysicsUpdate(double delta)
	{
		base.PhysicsUpdate(delta);
	}
}
