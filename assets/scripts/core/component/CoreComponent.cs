using Godot;
using System;

public partial class CoreComponent : Node
{
    protected Core core;

    public override void _EnterTree()
    {
        core = GetParent() as Core;

        if (core == null)
        {
            GD.PrintErr("There is no Core on the parent");
        }
    }
}