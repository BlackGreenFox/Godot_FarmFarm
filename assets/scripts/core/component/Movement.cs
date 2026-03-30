using Godot;
using System;
using static Godot.TextServer;

public partial class Movement : CoreComponent
{
    public CharacterBody2D CharacterBody { get; private set; }

    public Vector2 FacingDirection { get; private set; }
    public bool CanSetVelocity { get; set; }
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 _workspace;

    public override void _Ready()
    {
        base._Ready();

        CharacterBody = core.Player;

        FacingDirection = Vector2.Down;
        CanSetVelocity = true;
    }

    public void LogicUpdate(double delta)
    {
        CharacterBody.Velocity = CurrentVelocity;
        CharacterBody.MoveAndSlide();


        CurrentVelocity = CharacterBody.Velocity;
    }


    #region Setters

    public void SetVelocity(float velocity, Vector2 direction)
    {
        _workspace = direction.Normalized() * velocity;
        SetFinalVelocity();
    }

    public void SetVelosityZero()
    {
        _workspace = Vector2.Zero;
        SetFinalVelocity();
    }


    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            if (_workspace.X > 0)
                FacingDirection = Vector2.Right;
            else if (_workspace.X < 0)
                FacingDirection = Vector2.Left;
            else if (_workspace.Y > 0)
                FacingDirection = Vector2.Down;
            else if (_workspace.Y < 0)
                FacingDirection = Vector2.Up;

            CharacterBody.Velocity = _workspace;
            CurrentVelocity = _workspace;
        }
    }

    #endregion
}
