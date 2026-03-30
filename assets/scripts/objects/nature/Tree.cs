using Godot;
using System.Threading.Tasks;

public partial class Tree : Sprite2D, IDamage
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
        GD.Print($"Tree got {damage}, HP: {Health}");

        if (Health <= 0)
        {
            await ToSignal(GetTree().CreateTimer(0.5f), SceneTreeTimer.SignalName.Timeout);
            QueueFree();
            return;
        }

        var material = Material as ShaderMaterial;
        if (material != null)
        {
            await ToSignal(GetTree().CreateTimer(0.2f), SceneTreeTimer.SignalName.Timeout);
            material.SetShaderParameter("shake_intensity", 1.0f);

            await ToSignal(GetTree().CreateTimer(0.4f), SceneTreeTimer.SignalName.Timeout);
            material.SetShaderParameter("shake_intensity", 0.0f);
        }



    }
}