using Godot;
using System;
using System.IO;

public partial class PlayerMoveState : PlayerState
{

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        baseAnimationName = "walk";
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate(double delta)
    {
        base.LogicUpdate(delta);

        core.Movement.SetVelocity(player.data.MovementVelocity, player.inputHandler.Direction);

        if (!isExitingState)
        {
            if (player.inputHandler.Direction == Vector2.Zero)
            {
                stateMachine.ChangeState("IdleState");
                return;
            }
            if (player.inputHandler.OnToolInput)
            {
                stateMachine.ChangeState("ToolState");
            }
        }

        PlayDirectionalAnimation();
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
    }


}
