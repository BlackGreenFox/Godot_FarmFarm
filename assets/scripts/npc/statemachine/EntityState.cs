using Godot;
using System;

public partial class EntityState : Node
{
    public Core core;
    public Entity npc;
    public EntityStateMachine stateMachine;

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

        GD.Print($"ENTER STATE {GetType().Name}");
        PlayAnimation();
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

    protected void PlayAnimation()
    {
        if (string.IsNullOrEmpty(baseAnimationName))
            return;

        string anim = baseAnimationName;


        currentAnimation = anim;
        npc.anim.Play(anim);
    }


    public virtual void DoCheck()
    {

    }

    public virtual void OnAnimationFinished()
    {

    }
}
