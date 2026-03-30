using Godot;
using System;

public static class GenericNotImplementedError<T>
{
    public static T TryGet(T value, string name)
    {
        if (value != null)
        {
            return value;
        }

        GD.PrintErr(typeof(T) + " not implemented on " + name);
        return default;
    }
}