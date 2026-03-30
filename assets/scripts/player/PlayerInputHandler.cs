using Godot;
using System;
using static Godot.TextServer;



public partial class PlayerInputHandler : Node
{
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool OnToolInput { get; private set; }
    public Vector2 Direction { get; private set; }

    public override void _Process(double delta)
	{
		OnMoveInput();
        OnToolsInput();
	}

 	public void OnMoveInput()
	{
		Vector2 RawMovementInput = Input.GetVector("walk_left", "walk_right", "walk_up", "walk_down");

        if (RawMovementInput.X > 0)
            Direction = Vector2.Right;
        else if (RawMovementInput.X < 0)
            Direction = Vector2.Left;
        else if (RawMovementInput.Y > 0)
            Direction = Vector2.Down;
        else if (RawMovementInput.Y < 0)
            Direction = Vector2.Up;
        else
            Direction = Vector2.Zero;
    }

    public void OnToolsInput()
    {
        OnToolInput = Input.IsActionJustPressed("action_tool");
    }
}
