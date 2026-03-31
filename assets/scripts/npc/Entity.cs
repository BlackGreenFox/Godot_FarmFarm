using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    public Core core { get; private set; }
    public AnimatedSprite2D anim { get; private set; }
    public CharacterBody2D characterBody { get; private set; }

    public override void _EnterTree()
    {
        core = GetNode<Core>("./Core");
        anim = GetNode<AnimatedSprite2D>("./AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        core.LogicUpdate(delta);
    }
}
