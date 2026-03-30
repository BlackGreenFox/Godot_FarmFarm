using Godot;
using System;

public partial class HitComponent : Area2D
{
    [Export] public float Damage = 10f;

    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is DamageComponent damageComponent)
        {
            damageComponent.ReceiveDamage(Damage);
        }
    }
}
