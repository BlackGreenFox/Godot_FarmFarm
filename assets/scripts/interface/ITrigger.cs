using Godot;

public interface ITrigger 
{
    void OnFocusEntered(Node2D interactor);
    void OnFocusExited(Node2D interactor);
}
