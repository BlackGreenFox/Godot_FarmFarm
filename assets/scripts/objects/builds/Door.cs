using Godot;
using System;

public partial class Door : StaticBody2D, ITrigger
{
    private AnimatedSprite2D _animatedSprite;
    private CollisionShape2D _collisionShape;
    private TriggerComponent _triggerComponent;

    private bool _isOpen = false;
    private bool _isLock = false;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        _triggerComponent = GetNode<TriggerComponent>("TriggerComponent");
    }

    public void OnFocusEntered(Node2D interactor)
    {
        if (_isLock || _isOpen)
            return;
        Open();
    }

    public void OnFocusExited(Node2D interactor)
    {
        if (_isLock || !_isOpen)
            return;
        Close();
    }

    private void Open()
    {
        GD.Print("Player entered door trigger");
        _animatedSprite.Play("open_door");
        _collisionShape.SetDeferred("disabled", true);
        _isOpen = true;
    }

    private void Close()
    {
        GD.Print("Player exited door trigger");
        _animatedSprite.Play("close_door");
        _collisionShape.SetDeferred("disabled", false);
        _isOpen = false;
    }
}
