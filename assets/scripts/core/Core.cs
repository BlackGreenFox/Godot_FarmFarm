using Godot;
using System;

public partial class Core : Node
{
    private Entity _entity;
    private Movement _movement;

    public Entity Entity
    {
        get => GenericNotImplementedError<Entity>.TryGet(_entity, "No _entity Component");
        private set => _entity = value;
    }

    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(_movement, "No Movement Component");
        private set => _movement = value;
    }

    public override void _EnterTree()
    {
        Entity = GetParent() as Entity;
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
