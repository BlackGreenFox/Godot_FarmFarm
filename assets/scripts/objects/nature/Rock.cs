using Godot;
using System.Threading.Tasks;

public partial class Rock : Sprite2D, IDamage
{
    [Export] public float Health = 30f;
    [Export] public Tools ToolNeed = Tools.Axe;

    public async void TakeDamage(float damage)
    {
        //if (ToolNeed != PlayerStateMachine.CurrentTool)
        //{
        //    GD.Print("Wrong tool!");
        //    return;
        //}

        Health -= damage;
        GD.Print($"Rock got {damage}, HP: {Health}");

        if (Health <= 0)
        {
            await ToSignal(GetTree().CreateTimer(0.5f), SceneTreeTimer.SignalName.Timeout);
            QueueFree();
            return;
        }
    }
}
