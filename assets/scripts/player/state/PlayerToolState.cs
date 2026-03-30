using Godot;
using System;

public partial class PlayerToolState : PlayerState
{

    public override void DoCheck()
    {
        base.DoCheck();
    }



    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate(double delta)
    {
        base.LogicUpdate(delta);

        switch (player.currentTool)
        {
            case Tools.None:
                stateMachine.ChangeState("IdleState");
                break;
            case Tools.Axe:
                stateMachine.ChangeState("AxeState");
                break;
            case Tools.Hoe:
                stateMachine.ChangeState("HoeState");
                break;
            case Tools.WateringCan:
                stateMachine.ChangeState("WaterCanState");
                break;
            case Tools.Planting:
                stateMachine.ChangeState("PlantState");
                break;
            default:
                stateMachine.ChangeState("IdleState");
                break;
        }
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
    }
}

