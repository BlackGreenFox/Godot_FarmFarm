using Godot;

public partial class DamageComponent : Area2D
{
    public void ReceiveDamage(float damage)
    {
        var damageable = GetParent() as IDamage;

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}