using Godot;

public partial class TriggerComponent : Area2D
{
    private ITrigger _owner;

    public override void _Ready()
    {
        _owner = GetParent() as ITrigger;

        if (_owner == null)
        {
            GD.PushError($"{GetParent().Name} must implement IInteractable");
            return;
        }

        BodyEntered += OnBodyEntered;
        BodyExited += OnBodyExited;
    }

    private void OnBodyEntered(Node2D body)
    {
        _owner.OnFocusEntered(body);
        if (body.IsInGroup("player"))
            _owner.OnFocusEntered(body);
    }

    private void OnBodyExited(Node2D body)
    {
        _owner.OnFocusExited(body);
        if (body.IsInGroup("player"))
            _owner.OnFocusExited(body);
    }
}
