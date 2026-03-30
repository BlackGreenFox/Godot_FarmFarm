using Godot;
using System;

public partial class Core : Node
{
    private Player _player;
    private Movement _movement;

    public Player Player
    {
        get => GenericNotImplementedError<Player>.TryGet(_player, "No _entity Component");
        private set => _player = value;
    }

    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(_movement, "No Movement Component");
        private set => _movement = value;
    }

    public override void _EnterTree()
    {
        Player = GetParent() as Player;
        Movement = GetComponent<Movement>();
    }

    public void LogicUpdate(double delta)
    {
        Movement?.LogicUpdate(delta);
    }


    private T GetComponent<T>() where T : CoreComponent
    {
        foreach (var child in GetChildren())
        {
            if (child is T component)
                return component;
        }
        return null;
    }

}
