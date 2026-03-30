using Godot;
using System;

public partial class PlayerState : Node
{
  	public Core core;
	public Player player;
	public PlayerData playerData;
    public PlayerStateMachine stateMachine;

    protected float startTime;

    protected bool isAnimationFinished;
    protected bool isExitingState;
    protected bool exitOnAnimationEnd;

    public string baseAnimationName;
    protected string currentAnimation;

    public virtual void Enter()
    {
        DoCheck();
        isExitingState = false;
        isAnimationFinished = false;
        startTime = 0;

        PlayDirectionalAnimation();
    }


    public virtual void Exit()
	{
		isExitingState = true;
	}

	public virtual void LogicUpdate(double delta)
	{
   
    }

	public virtual void PhysicsUpdate(double delta)
	{
		DoCheck();
	}

    protected void PlayDirectionalAnimation()
    {
        if (string.IsNullOrEmpty(baseAnimationName))
            return;

        string anim = $"{baseAnimationName}_{GetDirection()}";


        currentAnimation = anim;
        GD.Print($"PLAY ANIM {anim}");
        player.anim.Play(anim);
    }
    
    private string GetDirection()
    {
        if (player.core.Movement.FacingDirection == Vector2.Up)
            return "up";
        if (player.core.Movement.FacingDirection == Vector2.Down)
            return "down";
        if (player.core.Movement.FacingDirection == Vector2.Left)
            return "left";

        return "right";
    }

	public virtual void DoCheck()
	{
		
	}

    public virtual void OnAnimationFinished()
    {

    }
}
